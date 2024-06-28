using Domain.Entities;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class SessionModelConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.Property(session => session.Id)
            .IsRequired(true)
            .HasConversion(
                value => value.Value,
                value => Id.CreateId(value));

        builder.OwnsOne(session => session.SessionSpan, span =>
        {
            span.Property(ss => ss.SessionStartValue)
                .HasColumnName(@"sessionStart")
                .IsRequired(true);
            span.Property(ss => ss.SessionEndValue)
                .HasColumnName(@"sessionEnd")
                .IsRequired(true);
        });

        builder.HasKey(session => session.Id)
            .IsClustered(false);

        builder.HasOne(session => session.Doctor)
            .WithMany(doc => doc.Sessions)
            .HasForeignKey(@"DoctorId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
