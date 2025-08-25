namespace GatePass.Core.Enums
{
    /// <summary>
    /// The type of a reservation in a ticket category represented as an integer.
    /// </summary>
    public enum ReservationType
    {
        /// <summary>
        /// A manual reservation by the organizer.
        /// This is the default value.
        /// </summary>
        Other = 0,

        /// <summary>
        /// Set aside for event staff, performers, or organizers.
        /// </summary>
        Crew = 10,

        /// <summary>
        /// Reserved for VIPs, guests of honor, or high-profile attendees.
        /// </summary>
        Vip = 20,

        /// <summary>
        /// Reserved for attendees with accessibility needs.
        /// </summary>
        Accessible = 21,

        /// <summary>
        /// Reserved for sponsors and partners.
        /// </summary>
        Sponsor = 30,

        /// <summary>
        /// Media/press people invited.
        /// </summary>
        Press = 31,

        /// <summary>
        /// For marketing campaigns, giveaways, or contests.
        /// </summary>
        Promotion = 40,
    }
}
