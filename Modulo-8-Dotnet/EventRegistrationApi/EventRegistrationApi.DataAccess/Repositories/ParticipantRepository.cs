using AutoMapper;
using EventRegistrationApi.DataAccess.Context;
using EventRegistrationApi.Domain.Abstractions.Entities;
using EventRegistrationApi.Domain.Abstractions.Repositories;
using EventRegistrationApi.Domain.Entities.Participants;
using EventRegistrationApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

using DalEntities = EventRegistrationApi.DataAccess.Entities;

namespace EventRegistrationApiApi.DataAccess.Repositories
{ 
    public class ParticipantRepository : IParticipantRepository
    {

        private readonly EventRegistrationApiDbContext _context;


        private readonly IMapper _mapper;

        public ParticipantRepository(EventRegistrationApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Participant> GetParticipant(int participantId)
        {
            var participant = await _context.Participants.SingleOrDefaultAsync(a => a.Id == participantId);
            if (participant is null)
            {
                throw new EntityNotFoundException($"Unable to find an participant with id {participantId}.");
            }

            return _mapper.Map<Participant>(participant);
        }

        public async Task<bool> ParticipantExists(int participantId)
        {
            return await _context.Participants.AnyAsync(a => a.Id == participantId);
        }

        public async Task<bool> ParticipantsExist(int[] participantIds)
        {
            return (await _context.Participants.CountAsync(a => participantIds.Contains(a.Id))) == participantIds.Length;
        }

        public Task<IIdentifiable> AddParticipant(Participant participant)
        {
            var dalParticipant = _mapper.Map<DalEntities.Participant>(participant);
            _context.Participants.Add(dalParticipant);
            return Task.FromResult((IIdentifiable)dalParticipant);
        }

        public async Task EditParticipant(Participant participant)
        {
            var participantFromDb = await _context.Participants.FindAsync(participant.Id);
            if (participantFromDb is null)
            {
                throw new EntityNotFoundException($"The participant with ID {participant.Id} was not found.");
            }

            _mapper.Map(participant, participantFromDb);
        }

        public async Task DeleteParticipant(int participantId)
        {
            var participantFromDb = await _context.Participants.FindAsync(participantId);
            if (participantFromDb is null)
            {
                throw new EntityNotFoundException($"The participant with ID {participantId} was not found.");
            }

            _context.Participants.Remove(participantFromDb);
        }
    }

}
