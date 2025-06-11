using EventRegistrationApi.Domain.Abstractions.Entities;


namespace EventRegistrationApi.DataAccess.Entities
{
    public class Participant : IIdentifiable
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required ICollection<Event> Events { get; set; }
    }
}
