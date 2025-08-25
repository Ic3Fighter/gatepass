namespace GatePass.Core.Enums
{
    /// <summary>
    /// The status of a ticket for an event represented as an integer.
    /// </summary>
    /// <remarks>
    /// The possible values in chronological order are: Purchased, Used, Expired
    /// </remarks>
    public enum TicketStatus
    {
        /// <summary>
        /// The ticket has been purchased for an event.
        /// This is the default value.
        /// </summary>
        Purchased = 10,

        /// <summary>
        /// The ticket has been used at the entrance to the event.
        /// </summary>
        Used = 20,

        /// <summary>
        /// The event for this ticket has completed already.
        /// </summary>
        Expired = 21,
    }
}
