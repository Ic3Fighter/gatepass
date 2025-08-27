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
        public async Task<Ticket?> PurchaseTicket(Ticket ticket)
        {
            // TODO get lock on category entity

            // get chosen category for ticket
            var category = await ticketCategoryBusinessProvider.GetAsync(ticket.TicketCategoryId);
            if (category == null) return null;

            // get event via category
            var @event = category.Event;

            // check status
            if (category.Status >= CategoryStatus.SoldOut || @event.Status >= EventStatus.SoldOut) return null;
            // check capacity (Event & Reservations)
            if (category.Capacity - category.CurrentCount - (category.Reservations?.Sum(x => x.Count) ?? 0) - 1 < 0) return null;

            // add ticket
            var ticketTask = ticketBusinessProvider.AddAsync(ticket);
            // increase CurrentCount
            category.CurrentCount++;
            var categoryTask = ticketCategoryBusinessProvider.UpdateAsync(category);
            // add EventJournal
            var journalTask = eventJournalBusinessProvider.AddAsync(new() { Type = JournalType.TicketSale, Count = 1, EventId = @event.Id });
            await Task.WhenAll(ticketTask, categoryTask, journalTask);
            
            // SAVE CHANGES!!
            ticketBusinessProvider.SaveChanges();
            
            return await ticketTask;
        }
    }
}
