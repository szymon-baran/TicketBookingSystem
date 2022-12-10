﻿using Microsoft.AspNetCore.Identity;

namespace TicketBookingSystem.Shared.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}