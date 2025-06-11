
namespace EventRegistrationApi.Domain.Entities.Events
{
    public record class EventDescription : ValueObject
    {

        public string Description { get; set; }

        public EventDescription(string description)
        {
            if (description is null || description.Length < 10 || description.Length > 4000)
            {
                AddValidationError("The description should contain between 10 and 4000 characters.");
            }

            Validate();

            this.Description = description ?? throw new ArgumentNullException(nameof(EventDescription));
        }
    }

}
