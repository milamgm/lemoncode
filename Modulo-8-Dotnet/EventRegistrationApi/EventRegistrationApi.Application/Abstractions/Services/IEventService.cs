using EventRegistrationApi.Application.Dtos.Commands.Events;
using FluentValidation.Results;

using EventRegistrationApi.Application.Dtos.Commands.Participants;

namespace EventRegistrationApi.Application.Abstractions.Services;

public interface IEventService
{
    Task<(ValidationResult ValidationResult, int? EventId)> AddEvent(EventDto eventDto);

    Task<ValidationResult> EditEvent(int eventId, EventDto eventDto);

    Task DeleteEvent(int eventId);

    Task<(ValidationResult ValidationResult, int? ParticipantId)> AddParticipantToEvent(int eventId, ParticipantDto participantDto);

    Task<ValidationResult> AddParticipantToEvent(int eventId, int participantId);
    Task<ValidationResult> RemoveParticipantFromEvent(int eventId, int participantId);

}
