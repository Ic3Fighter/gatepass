using GatePass.Business.BusinessProviders.Entities;
using GatePass.Business.Framework;
using GatePass.Core.Enums;
using GatePass.Data.Entities;

namespace GatePass.Business.BusinessProviders
{
    public class SaleBusinessProvider(TicketBusinessProvider ticketBusinessProvider,
        TicketCategoryBusinessProvider ticketCategoryBusinessProvider,
        EventJournalBusinessProvider eventJournalBusinessProvider)
        : IBusinessProvider
    {
        private readonly TicketBusinessProvider _ticketBusinessProvider = ticketBusinessProvider;
        private readonly TicketCategoryBusinessProvider _ticketCategoryBusinessProvider = ticketCategoryBusinessProvider;
        private readonly EventJournalBusinessProvider _eventJournalBusinessProvider = eventJournalBusinessProvider;

        public async Task<bool> PurchaseTicket(Ticket ticket)
        {
            // TODO get lock on category entity

            // get chosen category for ticket
            var category = await _ticketCategoryBusinessProvider.GetAsync(ticket.TicketCategoryId);
            if (category == null) return false;

            // get event via category
            var @event = category.Event;

            // check status
            if (category.Status >= CategoryStatus.SoldOut || @event.Status >= EventStatus.SoldOut) return false;
            // check capacity (Event & Reservations)
            if (category.Capacity - category.CurrentCount - (category.Reservations?.Sum(x => x.Count) ?? 0) - 1 < 0) return false;

            // add ticket
            var ticketTask = _ticketBusinessProvider.AddAsync(ticket);
            // increase CurrentCount
            category.CurrentCount++;
            var categoryTask = _ticketCategoryBusinessProvider.UpdateAsync(category);
            // add EventJournal
            var journalTask = _eventJournalBusinessProvider.AddAsync(new() { Type = JournalType.TicketSale, Count = 1, EventId = @event.Id });

            await Task.WhenAll(ticketTask, categoryTask, journalTask);
            // SAVE CHANGES!!
            _ticketBusinessProvider.SaveChanges();
            return true;
        }
    }
}
