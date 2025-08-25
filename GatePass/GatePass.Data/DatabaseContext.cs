using GatePass.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GatePass.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Event> Events { get; set; }

        public DbSet<TicketCategory> TicketCategories { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<EventJournal> EventJournals { get; set; }
    }
}
