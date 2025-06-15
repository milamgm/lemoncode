using System.Text.Json.Serialization;

namespace EventRegistrationApi.Application.Dtos.Commands.Events;

public class EventDto
{
    public enum OperationType
    {
        Add,
        Edit
    }

    [JsonIgnore]
    public OperationType Operation { get; set; }

    public int Id { get; set; }

    public required string Name { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public required string Description { get; set; }
}
