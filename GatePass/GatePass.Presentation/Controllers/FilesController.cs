using GatePass.Business.BusinessProviders;
using GatePass.Business.BusinessProviders.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GatePass.Presentation.Controllers
{
    [ApiController]
    public class FilesController(TicketBusinessProvider ticketBusinessProvider,
        PdfBusinessProvider pdfBusinessProvider) : ControllerBase
    {
        [HttpGet]
        [Route("ticket/{id:guid}/download")]
        public async Task<IActionResult> GetTicketPdf(Guid id)
        {
            // get ticket by id
            var ticket = await ticketBusinessProvider.GetAsync(id);
            if (ticket is null) return NotFound();

            // write pdf to a stream
            var stream = new MemoryStream();
            pdfBusinessProvider.GenerateTicket(ticket, stream);

            // reset stream after writing pdf
            stream.Position = 0;

            return File(stream, "application/pdf", "ticket.pdf");
        }
    }
}