using EventRegistrationApi.Application.Dtos.Queries.Events;
using EventRegistrationApi.Application.Dtos.Queries.Participants;

namespace EventRegistrationApi.Application.Abstractions.Queries;

public interface IEventQueriesService
{
    Task<EventDto> GetEvent(int eventId);

    Task<IList<EventDto>> GetUpcomingEvents(int limit);

    Task<IList<ParticipantDto>> GetParticipants(int eventId);
}
