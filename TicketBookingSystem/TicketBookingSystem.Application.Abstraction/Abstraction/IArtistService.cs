﻿using TicketBookingSystem.Shared;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Abstraction
{
    public interface IArtistService
    {
        Task<Artist> GetArtistById(int id);
        Task<PagedList<Artist>> GetArtists(PaginationParameters paginationParameters);
        Task<int> AddArtist(Artist artist);
        Task<bool> EditArtist(Artist artist);
        Task<bool> DeleteArtist(int id);
        Task<Dictionary<int, string>> GetArtistsToSelectList();
    }
}