using GatePass.Core.Enums;

namespace GatePass.Data.Entities
{
    /// <summary>
    /// A ticket for an <see cref="Event" />'s <see cref="Entities.TicketCategory" /> sold to a customer.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// A unique 32-bit identifier for this entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date and time of the ticket's purchase.
        /// </summary>
        public DateTime PurchasedAt { get; set; }

        /// <summary>
        /// The current status of the ticket category.
        /// For possible values see <see cref="TicketStatus" />.
        /// </summary>
        public TicketStatus Status { get; set; }

        /// <summary>
        /// Name of the customer who the Ticket is for.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Email address of the customer.
        /// Can be provided optionally for further updates on the event.
        /// </summary>
        public string? CustomerEmail { get; set; }

        #region Foreign Keys

        /// <summary>
        /// The <see cref="Entities.TicketCategory" /> the ticket has been purchased for.
        /// </summary>
        public Guid TicketCategoryId { get; set; }
        public virtual TicketCategory TicketCategory { get; set; }

        #endregion
    }
}
