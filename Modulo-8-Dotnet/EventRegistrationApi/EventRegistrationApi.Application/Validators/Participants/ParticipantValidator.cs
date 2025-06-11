using FluentValidation;
using EventRegistrationApi.Application.Dtos.Commands.Participants;


namespace EventRegistrationApi.Application.Validators.Participants;

public class ParticipantValidator : AbstractValidator<ParticipantDto>
{
    public ParticipantValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .Length(1, 100)
            .WithMessage("The participant name should contain between 1 and 100 characters.");

        RuleFor(p => p.LastName)
            .NotNull()
            .NotEmpty()
            .Length(1, 100)
            .WithMessage("The participant last name should contain between 1 and 100 characters.");
        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .Length(1, 100)
            .WithMessage("The participant email should contain between 1 and 100 characters.");
    }
}