using EventRegistrationApi.Application.Dtos.Commands.Participants;
using EventRegistrationApi.Domain.Entities.Participants;

namespace EventRegistrationApi.Application.Extensions.Mappers;

internal static class ParticipantMapperExtensions
{

    public static ParticipantDto ConverToDto(this Participant Participant)
    {
        return new ParticipantDto
        {
            Name = Participant.Name,
            Id = Participant.Id,
            LastName = Participant.LastName,
            Email = Participant.Email
        };
    }

    public static Participant ConvertToDomainEntity(this ParticipantDto participantDto)
    {
        return new Participant(
            id: participantDto.Id,
            firstName: participantDto.Name,
            lastName: participantDto.LastName,
            email: participantDto.Email
            );
    }
}
