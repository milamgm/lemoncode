using EventRegistrationApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace EventRegistrationApi.DataAccess.Context;

public class EventRegistrationApiDbContext : DbContext
{

    public EventRegistrationApiDbContext(DbContextOptions<EventRegistrationApiDbContext> options) : base(options)

    {
    }

    public DbSet<Event> Events { get; set; }

    public DbSet<Participant> Participants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventRegistrationApiDbContext).Assembly);
    }
}
