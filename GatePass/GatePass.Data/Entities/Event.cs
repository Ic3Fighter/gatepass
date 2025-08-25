using GatePass.Core.Enums;

namespace GatePass.Data.Entities
{
    /// <summary>
    /// Core entity containing all information about an event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// A unique 32-bit identifier for this entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user-custom title given to the event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A more verbose description about the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The exact starting day and time of the event.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// The planned ending day and time of the event.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// A free-text name and description of the location where the event is taking place.
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// An optional custom note for the customer by the organizer.
        /// </summary>
        public string? NoteForCustomer { get; set; }

        /// <summary>
        /// Automatically set date and time of the event's creation.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Date and time of the last update of this entity.
        /// </summary>
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// The current status of the event.
        /// For possible values see <see cref="EventStatus" />.
        /// </summary>
        public EventStatus Status { get; set; }

        /// <summary>
        /// Projected sum of all ticket category's <see cref="TicketCategory.CurrentCount" /> values.
        /// </summary>
        public int? Occupancy => Categories?.Sum(x => x.CurrentCount);

        #region Foreign Keys

        /// <summary>
        /// All <see cref="TicketCategory" />s for the event.
        /// </summary>
        public virtual List<TicketCategory> Categories { get; set; }

        /// <summary>
        /// Statistical tracking of important events in the <see cref="Event" />.
        /// </summary>
        public virtual List<EventJournal> EventJournals { get; set; }

        #endregion
    }
}
