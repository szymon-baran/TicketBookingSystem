﻿using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Data.Abstraction
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<List<Artist>> GetArtists();
    }
}
