﻿using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Ticket>> GetTicketsAsync(string userId)
        {
            return await _context.Tickets.Where(x => x.ApplicationUserId == userId)
                                        .Include(x => x.Event)
                                        .ToListAsync();
        }
    }
}
