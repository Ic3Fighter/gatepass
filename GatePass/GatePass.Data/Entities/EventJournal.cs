using GatePass.Core.Enums;

namespace GatePass.Data.Entities
{
    /// <summary>
    /// Statistics tracking for the event.
    /// </summary>
    public class EventJournal
    {
        /// <summary>
        /// A unique 32-bit identifier for this entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The type of this history entity.
        /// For possible values see <see cref="JournalType" />.
        /// </summary>
        public JournalType Type { get; set; }

        /// <summary>
        /// Optional count associated with the <see cref="Type" />
        /// </summary>
        public double? Count { get; set; }

        #region Foreign Keys

        /// <summary>
        /// The <see cref="Event" /> the history entry belongs to.
        /// </summary>
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        #endregion
    }
}
