using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventRegistrationApi.DataAccess.Entities;

namespace EventRegistrationApi.DataAccess.EntityTypeConfiguration
{
    public class ParticipantEntityTypeConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.HasMany(p => p.Events)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>();
        }
    }
}
