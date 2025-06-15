using FluentValidation;
using EventRegistrationApi.Application.Dtos.Commands.Events;

namespace EventRegistrationApi.Application.Validators.Events
{
    public class EventValidator : AbstractValidator<EventDto>
    {
        public EventValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("The event name should contain between 1 and 100 characters.");

            RuleFor(e => e.StartDate)
                .NotNull()
                .WithMessage("Start date is required.");

            RuleFor(e => e)
                .Must(e => e.StartDate <= e.EndDate)
                .WithMessage("The start date must be before or equal to the end date.");

            RuleFor(e => e.Description)
                .NotNull()
                .NotEmpty()
                .Length(1, 500)
                .WithMessage("The event description should contain between 1 and 500 characters.");

        }
    }
}
