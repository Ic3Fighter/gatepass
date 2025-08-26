using GatePass.Data.Entities;
using GatePass.Data.Framework;

namespace GatePass.Data.DataProviders.Entities
{
    public class TicketCategoryDataProvider(DatabaseContext context)
        : IdDataProvider<TicketCategory, Guid>(context)
    {
    }
}
