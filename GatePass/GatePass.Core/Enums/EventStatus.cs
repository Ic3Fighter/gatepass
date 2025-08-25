namespace GatePass.Core.Enums
{
    /// <summary>
    /// The status of an event represented as an integer.
    /// </summary>
    /// <remarks>
    /// The possible values in chronological order are: Template, Published, SoldOut, Ongoing, Completed, Canceled
    /// </remarks>
    public enum EventStatus
    {
        /// <summary>
        /// The event is only a template without any customer action possible.
        /// </summary>
        Template = 0,

        /// <summary>
        /// The event is publicly available and tickets can be reserved for it.
        /// This is the default value.
        /// </summary>
        Published = 10,

        /// <summary>
        /// The maximum capacity is reached and the event, thus, sold out.
        /// </summary>
        SoldOut = 20,

        /// <summary>
        /// The event is currently in action.
        /// </summary>
        Ongoing = 30,

        /// <summary>
        /// The event was completed successfully.
        /// </summary>
        Completed = 40,

        /// <summary>
        /// The event has been canceled for any reason.
        /// </summary>
        Canceled = 41,
    }
}
