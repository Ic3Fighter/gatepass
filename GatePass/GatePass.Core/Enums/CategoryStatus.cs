namespace GatePass.Core.Enums
{
    /// <summary>
    /// The status of a ticket category in an event represented as an integer.
    /// </summary>
    /// <remarks>
    /// The possible values in chronological order are: Template, Open, SoldOut, Disabled
    /// </remarks>
    public enum CategoryStatus
    {
        /// <summary>
        /// The ticket category is only a template without any customer action possible.
        /// </summary>
        Template = 0,

        /// <summary>
        /// The ticket category is open for reservation.
        /// This is the default value.
        /// </summary>
        Open = 10,

        /// <summary>
        /// The maximum capacity is reached and the ticket category is, thus, sold out.
        /// </summary>
        SoldOut = 20,

        /// <summary>
        /// The ticket category is temporarily disabled from reservations.
        /// May open again in the future.
        /// </summary>
        Disabled = 21,
    }
}
