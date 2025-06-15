using EventRegistrationApi.Application.Dtos.Queries.Participants;

namespace EventRegistrationApi.Application.Dtos.Queries.Events;

public class EventDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime Created { get; set; }

    public required List<ParticipantDto> Participants { get; set; }

    public int ParticipantCount => Participants?.Count ?? 0;
}
