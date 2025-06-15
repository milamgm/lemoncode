using EventRegistrationApi.Domain.Entities.Participants;
using System.Diagnostics.CodeAnalysis;


namespace EventRegistrationApi.Domain.Entities.Events
{
    public class Event : Entity
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required EventDescription Description { get; set; }
        public required ICollection<Participant> Participants { get; set; } = new List<Participant>();

        [SetsRequiredMembers]
        public Event(int id, string name, DateTime startDate, DateTime? endDate, EventDescription description, ICollection<Participant> participants)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Participants = participants ?? new List<Participant>();
            EnsureStateIsValid();
        }

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

        public void AddParticipant(Participant participant)
        {
            Participants.Add(participant);
        }

        protected override void EnsureStateIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddValidationError("The name is mandatory.");
            }

            Validate();
        }
    }
}

