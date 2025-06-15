using EventRegistrationApi.Application.Dtos.Commands.Events;
using EventRegistrationApi.Domain.Entities.Events;
using EventRegistrationApi.Domain.Entities.Participants;

internal static class EventMapperExtensions
{
    public static Event ConvertToDomainEntity(this EventDto eventDto)
    {
        return new Event(
            id: eventDto.Id,
            name: eventDto.Name,
            startDate: eventDto.StartDate,
            endDate: eventDto.EndDate,
            description: new EventDescription(eventDto.Description),
            participants: new List<Participant>()
        );
    }
}
