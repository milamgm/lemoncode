using EventRegistrationApi.Domain.Entities.Participants;
using EventRegistrationApi.Domain.Entities.Exceptions;


namespace EventRegistrationApi.Domain.Entities.Events
{
    public class Event : Entity
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required EventDescription Description { get; set; }
        public required ICollection<Participant> Participants { get; set; }


        public void UpdateName(string name)
        {
            Name = name;
            EnsureStateIsValid();
        }

        public void UpdateStartDate(DateTime startDate)
        {
            StartDate = startDate;
            EnsureStateIsValid();
        }

        public void UpdateEndDate(DateTime? endDate)
        {
            EndDate = endDate;
            EnsureStateIsValid();
        }

        public void UpdateParticipants(ICollection<Participant> participant)
        {
            Participants = participant;
            EnsureStateIsValid();
        }

        public void UpdateDescription(string description)
        {
            this.Description = new EventDescription(description);
        }


        public Event(int id, string name, DateTime startDate, DateTime endDate, EventDescription description, ICollection<Participant> participants)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Participants = participants;
            EnsureStateIsValid(); 
        }


        protected override void EnsureStateIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddValidationError("The name is mandatory.");
            }

            if (!Participants.Any())
            {
                AddValidationError("The event should have at least one participant.");
            }

            Validate();
        }
    }
}

