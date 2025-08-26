using GatePass.Data.Entities;
using GatePass.Data.Framework;

namespace GatePass.Data.DataProviders.Entities
{
    public class TicketDataProvider(DatabaseContext context)
        : IdDataProvider<Ticket, Guid>(context)
    {
    }
}
