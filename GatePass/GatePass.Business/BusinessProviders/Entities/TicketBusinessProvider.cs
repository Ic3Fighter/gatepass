using GatePass.Business.Framework;
using GatePass.Data.DataProviders.Entities;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders.Entities
{
    public class TicketBusinessProvider(TicketDataProvider dataProvider)
        : IdBusinessProvider<Ticket, Guid, TicketDataProvider>(dataProvider)
    {
    }
}
