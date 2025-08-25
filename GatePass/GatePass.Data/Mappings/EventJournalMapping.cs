using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatePass.Data.Mappings
{
    public class EventJournalMapping : IEntityTypeConfiguration<EventJournal>
    {
        public void Configure(EntityTypeBuilder<EventJournal> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e =>  e.Id).ValueGeneratedOnAdd();
        }
    }
}
