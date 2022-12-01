﻿using System.Threading.Tasks;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Client.Abstraction
{
    public interface ITicketService
    {
        List<Ticket> Tickets { get; set; }
        Task BuyTicket(BuyOperationVM model);
    }
}