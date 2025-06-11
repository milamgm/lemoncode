
namespace EventRegistrationApi.Application.Dtos.Queries.Participants;

public class ParticipantWithEventCountDto
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public required string LastName { get; set; }

    public int EventCount { get; set; }

}
