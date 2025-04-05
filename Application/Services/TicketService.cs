using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TakeLeaveMngSystem.Application.Exceptions;
using TakeLeaveMngSystem.Domains.Models;
using TakeLeaveMngSystem.Infrastructure.Data;

namespace TakeLeaveMngSystem.Application.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Ticket>> GetByEmployeeCode(string employeeCode)
        {
            List<Ticket> tickets = await _context.Ticket.Where(x => x.EmployeeCode == employeeCode).ToListAsync();

            return tickets;
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.Ticket.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            _context.Ticket.Add(ticket);

            await _context.SaveChangesAsync();

            //get next approval

            //send mail


            return ticket;
        }

        public async Task<Ticket> Update(Ticket ticket)
        {
            var newTicket = await _context.Ticket.FindAsync(ticket.Id) ?? throw new NotFoundException("Ticket not found!");

            newTicket = ticket;

            _context.Ticket.Update(ticket);

            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task Delete(Guid id)
        {
            Ticket ticket = await _context.Ticket.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("Not found ticket!");

            _context.Ticket.Remove(ticket);

            await _context.SaveChangesAsync();
        }
    }
}
