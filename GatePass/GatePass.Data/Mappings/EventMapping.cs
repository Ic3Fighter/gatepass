using GatePass.Core.Enums;
using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatePass.Data.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e =>  e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.Status).HasDefaultValue(EventStatus.Published);

            builder.HasMany(e => e.Categories).WithOne(e => e.Event).HasForeignKey(k => k.EventId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.EventJournals).WithOne(e => e.Event).HasForeignKey(k => k.EventId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
