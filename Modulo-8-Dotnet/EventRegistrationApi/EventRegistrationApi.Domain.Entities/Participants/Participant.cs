using System.Diagnostics.CodeAnalysis;
using EventRegistrationApi.Domain.Entities.Events;

namespace EventRegistrationApi.Domain.Entities.Participants
{
    public class Participant : Entity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required ICollection<Event> Events { get; set; } = new List<Event>();

        [SetsRequiredMembers]
        public Participant(int id, string firstName, string lastName, string email)
        {
            Id = id;
            Name = firstName;
            LastName = lastName;
            Email = email;
            EnsureStateIsValid();
        }

        public void UpdateName(string firstName)
        {
            Name = firstName;
            EnsureStateIsValid();
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
            EnsureStateIsValid();
        }

        public void UpdateEmail(string email)
        {
            Email = email;
            EnsureStateIsValid();
        }

        protected override void EnsureStateIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length > 100)
            {
                AddValidationError("First name must contain between 1 and 100 characters, and not be empty.");
            }

            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length > 100)
            {
                AddValidationError("Last name must contain between 1 and 100 characters, and not be empty.");
            }

            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email))
            {
                AddValidationError("Email must be a valid email address and not be empty.");
            }

            Validate();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
