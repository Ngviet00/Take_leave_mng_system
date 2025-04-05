using Microsoft.AspNetCore.Mvc;
using TakeLeaveMngSystem.Application.DTOs;
using TakeLeaveMngSystem.Application.Exceptions;
using TakeLeaveMngSystem.Application.Services;
using TakeLeaveMngSystem.Domains.Models;

namespace TakeLeaveMngSystem.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("/get-by-employee-code/{employeeCode}")]
        public async Task<IActionResult> GetByEmployeeCode(string employeeCode)
        {
            List<Ticket> tickets = await _ticketService.GetByEmployeeCode(employeeCode);

            return Ok(new BaseResponse<List<Ticket>>(200, "Success", tickets));
        }

        [HttpGet("/get-by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ticket = await _ticketService.GetById(id) ?? throw new NotFoundException("Not found ticket!");

            return Ok(new BaseResponse<Ticket>(200, "success", ticket));
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            await _ticketService.Create(ticket);

            return Ok(new BaseResponse<Ticket>(200, "Create ticket successfully", ticket));
        }

        [HttpPut("/update")]
        public async Task<IActionResult> Update(Ticket ticket)
        {
            Ticket newTicket = await _ticketService.Update(ticket);

            return Ok(new BaseResponse<Ticket>(200, "Update ticket successfully", newTicket));
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ticketService.Delete(id);

            return Ok(new BaseResponse<bool>(200, "Delete ticket successfully", true));
        }
    }
}
