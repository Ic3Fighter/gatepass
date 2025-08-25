using GatePass.Core.Enums;
using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatePass.Data.Mappings
{
    public class TicketCategoryMapping : IEntityTypeConfiguration<TicketCategory>
    {
        public void Configure(EntityTypeBuilder<TicketCategory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e =>  e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Status).HasDefaultValue(CategoryStatus.Open);

            builder.HasMany(e => e.Tickets).WithOne(e => e.TicketCategory).HasForeignKey(k => k.TicketCategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Reservations).WithOne(e => e.TicketCategory).HasForeignKey(k => k.TicketCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
