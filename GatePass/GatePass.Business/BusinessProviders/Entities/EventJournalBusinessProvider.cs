using GatePass.Business.Framework;
using GatePass.Data.DataProviders.Entities;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders.Entities
{
    public class EventJournalBusinessProvider(EventJournalDataProvider dataProvider)
        : IdBusinessProvider<EventJournal, Guid, EventJournalDataProvider>(dataProvider)
    {
    }
}
