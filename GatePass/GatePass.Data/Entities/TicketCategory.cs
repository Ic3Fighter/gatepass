using GatePass.Core.Enums;

namespace GatePass.Data.Entities
{
    /// <summary>
    /// A ticket category for one specific event.
    /// </summary>
    public class TicketCategory
    {
        /// <summary>
        /// A unique 32-bit identifier for this entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Custom name of the ticket category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current status of the ticket category.
        /// For possible values see <see cref="CategoryStatus" />.
        /// </summary>
        public CategoryStatus Status { get; set; }

        /// <summary>
        /// A free-text note for the customer by the organizer.
        /// </summary>
        public string? NoteForCustomer { get; set; }

        /// <summary>
        /// The projected price of the ticket category.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// The maximum possible capacity for the event.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The current amount of reserved tickets for the event.
        /// </summary>
        public int CurrentCount { get; set; }

        #region Foreign Keys

        /// <summary>
        /// Id of the <see cref="Entities.Event" /> associated with the ticket category.
        /// </summary>
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        /// <summary>
        /// All <see cref="Ticket" />s purchased for the ticket category.
        /// </summary>
        public virtual List<Ticket> Tickets { get; set; }

        /// <summary>
        /// All <see cref="Reservation" />s made for the ticket category.
        /// </summary>
        public virtual List<Reservation> Reservations { get; set; }

        #endregion
    }
}
