using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventRegistrationApi.DataAccess.Entities;

namespace EventRegistrationApi.DataAccess.EntityTypeConfiguration
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(e => e.StartDate)
                .IsRequired(true);

            builder.Property(e => e.EndDate)
                .IsRequired(false);

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.HasMany(e => e.Participants)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>();
        }
    }
}
