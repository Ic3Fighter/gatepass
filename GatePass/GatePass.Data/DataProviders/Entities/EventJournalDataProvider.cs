using GatePass.Data.Entities;
using GatePass.Data.Framework;

namespace GatePass.Data.DataProviders.Entities
{
    public class EventJournalDataProvider(DatabaseContext context)
        : IdDataProvider<EventJournal, Guid>(context)
    {
    }
}
