using GatePass.Business.Framework;
using GatePass.Data.DataProviders.Entities;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders.Entities
{
    public class EventBusinessProvider(EventDataProvider dataProvider)
        : IdBusinessProvider<Event, Guid, EventDataProvider>(dataProvider)
    {
    }
}
