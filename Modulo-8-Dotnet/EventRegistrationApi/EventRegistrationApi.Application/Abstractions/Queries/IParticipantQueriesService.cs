using EventRegistrationApi.Application.Dtos.Queries.Participants;

namespace EventRegistrationApi.Application.Abstractions.Queries;

public interface IParticipantQueriesService
{

    Task<List<ParticipantWithEventCountDto>> GetParticipants();
    Task<ParticipantWithEventCountDto> GetParticipantById(int ParticipantId);
}

