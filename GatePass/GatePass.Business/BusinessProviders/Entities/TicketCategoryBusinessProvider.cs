using GatePass.Business.Framework;
using GatePass.Data.DataProviders.Entities;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders.Entities
{
    public class TicketCategoryBusinessProvider(TicketCategoryDataProvider dataProvider)
                : IdBusinessProvider<TicketCategory, Guid, TicketCategoryDataProvider>(dataProvider)
    {
    }
}
