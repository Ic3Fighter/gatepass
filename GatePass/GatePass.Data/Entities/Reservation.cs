using GatePass.Core.Enums;

namespace GatePass.Data.Entities
{
    /// <summary>
    /// A manual, up-front reservation in a <see cref="TicketCategory" /> for an <see cref="Event" /> by the organizer.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// A unique 32-bit identifier for this entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The type of this reservation.
        /// For possible values see <see cref="ReservationType" />.
        /// </summary>
        public ReservationType Type { get; set; }

        /// <summary>
        /// The amount of tickets to reserve.
        /// </summary>
        public int Count { get; set; }

        #region Foreign Keys

        /// <summary>
        /// The <see cref="TicketCategory" /> the reservation is made for.
        /// </summary>
        public Guid TicketCategoryId { get; set; }
        public virtual TicketCategory TicketCategory { get; set; }

        #endregion
    }
}
