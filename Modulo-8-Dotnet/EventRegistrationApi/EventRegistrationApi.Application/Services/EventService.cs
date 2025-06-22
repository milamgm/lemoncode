using FluentValidation.Results;
using EventRegistrationApi.Application.Abstractions.Services;
using EventRegistrationApi.Application.Dtos.Commands.Events;
using EventRegistrationApi.Application.Dtos.Commands.Participants;
using EventRegistrationApi.Application.Extensions.Mappers;
using EventRegistrationApi.Domain.Abstractions.Repositories;
using EventRegistrationApi.Domain.Entities.Events;
using EventRegistrationApi.Domain.Entities.Participants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using EventRegistrationApi.DataAccess.Context;

namespace EventRegistrationApi.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IValidator<EventDto> _eventDtoValidator;
        private readonly IEventRepository _eventRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EventRegistrationApiDbContext _context;

        public EventService(
            IValidator<EventDto> eventDtoValidator,
            IEventRepository eventRepository,
            IParticipantRepository participantRepository,
            IUnitOfWork unitOfWork,
            EventRegistrationApiDbContext context)
        {
            _eventDtoValidator = eventDtoValidator;
            _eventRepository = eventRepository;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<(ValidationResult ValidationResult, int? EventId)> AddEvent(EventDto eventDto)
        {
            var validationResult = _eventDtoValidator.Validate(eventDto);
            if (validationResult.IsValid)
            {
                var eventEntity = eventDto.ConvertToDomainEntity();
                var repoResult = await _eventRepository.AddEvent(eventEntity);
                await _unitOfWork.CommitAsync();
                return (validationResult, repoResult.Id);
            }

            return (validationResult, null);
        }

        public async Task<ValidationResult> EditEvent(int eventId, EventDto eventDto)
        {
            var validationResult = _eventDtoValidator.Validate(eventDto);
            if (validationResult.IsValid)
            {
                Event eventEntity;
                try
                {
                    eventEntity = await _eventRepository.GetEvent(eventId);
                }
                catch (Domain.Exceptions.EntityNotFoundException ex)
                {
                    throw new Application.Exceptions.EntityNotFoundException($"Unable to find an Event with id {eventId}.", ex);
                }

                eventEntity.UpdateName(eventDto.Name);
                eventEntity.UpdateStartDate(eventDto.StartDate);
                eventEntity.UpdateEndDate(eventDto.EndDate);
                eventEntity.UpdateDescription(eventDto.Description);

                await _eventRepository.EditEvent(eventEntity);
                await _unitOfWork.CommitAsync();
            }

            return validationResult;
        }

        public async Task DeleteEvent(int eventId)
        {
            await _eventRepository.DeleteEvent(eventId);
            await _unitOfWork.CommitAsync();
        }

        public async Task<(ValidationResult ValidationResult, int? ParticipantId)> AddParticipantToEvent(int eventId, ParticipantDto participantDto)
        {
            var validationResult = new ValidationResult();
            var participantEntity = participantDto.ConvertToDomainEntity();

            Event eventEntity;
            try
            {
                eventEntity = await _eventRepository.GetEvent(eventId);
            }
            catch (Domain.Exceptions.EntityNotFoundException ex)
            {
                throw new Application.Exceptions.EntityNotFoundException($"Unable to find an Event with id {eventId}.", ex);
            }

            eventEntity.AddParticipant(participantEntity);
            await _participantRepository.AddParticipant(participantEntity);
            await _eventRepository.EditEvent(eventEntity);
            await _unitOfWork.CommitAsync();

            return (validationResult, participantEntity.Id);
        }

        public async Task<ValidationResult> AddParticipantToEvent(int eventId, int participantId)
        {
            var validationResult = new ValidationResult();

            var evento = await _context.Events
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (evento == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Event", "Evento no encontrado"));
                return validationResult;
            }

            var participant = await _context.Participants.FindAsync(participantId);
            if (participant == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Participant", "Participante no encontrado"));
                return validationResult;
            }

            if (evento.Participants.Any(p => p.Id == participantId))
            {
                validationResult.Errors.Add(new ValidationFailure("Participant", "Ya está inscrito"));
                return validationResult;
            }

            evento.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return validationResult;
        }

        public async Task<ValidationResult> RemoveParticipantFromEvent(int eventId, int participantId)
        {
            var validationResult = new ValidationResult();

            var evento = await _context.Events
                .Include(e => e.Participants)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (evento == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Event", "Evento no encontrado"));
                return validationResult;
            }

            var participant = evento.Participants.FirstOrDefault(p => p.Id == participantId);
            if (participant == null)
            {
                validationResult.Errors.Add(new ValidationFailure("Participant", "Participante no está inscrito en este evento"));
                return validationResult;
            }

            evento.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return validationResult;
        }
    }
}
