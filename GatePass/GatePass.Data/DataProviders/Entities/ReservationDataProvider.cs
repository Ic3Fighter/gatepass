using GatePass.Data.Entities;
using GatePass.Data.Framework;

namespace GatePass.Data.DataProviders.Entities
{
    public class ReservationDataProvider(DatabaseContext context)
        : IdDataProvider<Reservation, Guid>(context)
    {
    }
}
