using GatePass.Business.Framework;
using GatePass.Data.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GatePass.Business.BusinessProviders
{
    public class PdfBusinessProvider : IBusinessProvider
    {
        private const float LineHeight = 3;

        public void GenerateTicket(Ticket ticket, Stream stream)
        {
            Document.Create(pdf =>
            {
                // entire page
                pdf.Page(page =>
                {
                    // set page to A4
                    page.Size(PageSizes.A4);

                    // margin to the sides
                    page.Margin(2, Unit.Centimetre);

                    page.Header().Element(container => GenerateHeader(container, ticket));
                    page.Content().Element(container => GenerateContent(container, ticket));
                    page.Footer().Element(GenerateFooter);
                });
            }).WithMetadata(new()
            {
                Title = $"Ticket for {ticket.CustomerName}",
                Author = "",
                Creator = "GatePass",
                Producer = "QuestPDF",
                CreationDate = DateTimeOffset.Now,
                ModifiedDate = DateTimeOffset.Now,
                Language = Thread.CurrentThread.CurrentCulture.DisplayName,
            }).GeneratePdf(stream);
        }

        private void GenerateHeader(IContainer container, Ticket ticket)
        {
            container.Row(row =>
            {
                // left column
                row.RelativeItem().Column(column =>
                {
                    var ev = ticket.TicketCategory.Event;
                    column.Item().Text(ev.Organizer).Bold().FontSize(20);
                    column.Item().Text(ev.Title).FontSize(20);
                    column.Item().Text("");
                    column.Item().PaddingVertical(LineHeight)
                        .Text($"Ticket valid for {ticket.CustomerName}");
                    column.Item().Text("Reservation only").Bold().Underline();
                });

                // right column
                row.RelativeItem().Column(column =>
                {
                    column.Item().AlignRight().Height(6, Unit.Centimetre).Image(QrCodeBusinessProvider.Encode(ticket.Id.ToString()));
                });
            });
        }

        private void GenerateContent(IContainer container, Ticket ticket)
        {
            var category = ticket.TicketCategory;
            var ev = ticket.TicketCategory.Event;

            // event info headline
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().PaddingBottom(.25f, Unit.Centimetre)
                        .Text("Event Information").Bold().FontSize(16);

                    // event info table
                    column.Item().Table(table =>
                    {
                        // columns definition => 2 columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        // table content
                        // title
                        table.Cell().PaddingVertical(LineHeight).Text("Name");
                        table.Cell().PaddingVertical(LineHeight).Text(ev.Title);

                        // date
                        table.Cell().PaddingVertical(LineHeight).Text("Date");
                        table.Cell().PaddingVertical(LineHeight).Text(ev.End - ev.Start > TimeSpan.FromDays(1)
                            ? $"{ev.Start:d} - {ev.End:d}"
                            : $"{ev.Start:D}");

                        // time
                        table.Cell().PaddingVertical(LineHeight).Text("Starting time");
                        table.Cell().PaddingVertical(LineHeight).Text($"{ev.Start:t}");

                        // location
                        table.Cell().PaddingVertical(LineHeight).Text("Event location");
                        table.Cell().PaddingVertical(LineHeight).Text(ev.LocationName);
                    });

                    // category headline
                    column.Item().PaddingBottom(.25f, Unit.Centimetre).PaddingTop(1, Unit.Centimetre)
                        .Text("Ticket").Bold().FontSize(16);

                    // event info table
                    column.Item().Table(table =>
                    {
                        // columns definition => 2 columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        // table content
                        // title
                        table.Cell().PaddingVertical(LineHeight).Text("Ticket Type");
                        table.Cell().PaddingVertical(LineHeight).Text(category.Name);

                        // time
                        table.Cell().PaddingVertical(LineHeight).Text("Price");
                        table.Cell().PaddingVertical(LineHeight).Text($"{category.Price:N2}"); // TODO add currency identifier

                        // purchase datetime
                        table.Cell().PaddingVertical(LineHeight).Text("Purchase date");
                        table.Cell().PaddingVertical(LineHeight).PaddingVertical(LineHeight);
                    });

                    // organizer notes, if available
                    if (!string.IsNullOrEmpty(ev.NoteForCustomer) && !string.IsNullOrEmpty(category.NoteForCustomer))
                    {
                        column.Item().PaddingBottom(.25f, Unit.Centimetre).PaddingTop(1, Unit.Centimetre)
                            .Text("Organizer's notes:").Bold().FontSize(16);

                        if (!string.IsNullOrEmpty(ev.NoteForCustomer))
                            column.Item().Text(ev.NoteForCustomer);

                        if (!string.IsNullOrEmpty(category.NoteForCustomer))
                            column.Item().Text(category.NoteForCustomer);
                    }
                });
            });
        }

        private void GenerateFooter(IContainer container)
        {
            container.AlignRight().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span("/");
                x.TotalPages();
            });
        }
    }
}
