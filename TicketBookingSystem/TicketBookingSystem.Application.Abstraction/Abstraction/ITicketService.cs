﻿using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface ITicketService
    {
        Task<List<ReservedTicketVM>> GetReservedTicketsVMAsync(string userId);
        Task<int> BuyTicket(BuyOperationVM model, string userId);
    }
}