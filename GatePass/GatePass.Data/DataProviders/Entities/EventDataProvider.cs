using GatePass.Data.Entities;
using GatePass.Data.Framework;

namespace GatePass.Data.DataProviders.Entities
{
    public class EventDataProvider(DatabaseContext context) 
        : IdDataProvider<Event, Guid>(context)
    {
    }
}
