using GatePass.Core.Enums;
using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatePass.Data.Mappings
{
    public class TicketMapping : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e =>  e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.PurchasedAt).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.Status).HasDefaultValue(TicketStatus.Purchased);
        }
    }
}
