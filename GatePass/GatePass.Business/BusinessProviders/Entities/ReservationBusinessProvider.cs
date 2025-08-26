using GatePass.Business.Framework;
using GatePass.Data.DataProviders.Entities;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders.Entities
{
    public class ReservationBusinessProvider(ReservationDataProvider dataProvider)
        : IdBusinessProvider<Reservation, Guid, ReservationDataProvider>(dataProvider)
    {
    }
}
