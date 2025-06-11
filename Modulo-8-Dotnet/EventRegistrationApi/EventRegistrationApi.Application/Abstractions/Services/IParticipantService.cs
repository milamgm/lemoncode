using FluentValidation.Results;
using EventRegistrationApi.Application.Dtos.Commands.Participants;
namespace EventRegistrationApi.Application.Abstractions.Services
{
    public interface IParticipantService
    {
        Task<(ValidationResult ValidationResult, int? ParticipantId)> AddParticipant(ParticipantDto Participant);

        Task<ValidationResult> EditParticipant(ParticipantDto Participant);

        Task DeleteParticipant(int ParticipantId);
    }
}