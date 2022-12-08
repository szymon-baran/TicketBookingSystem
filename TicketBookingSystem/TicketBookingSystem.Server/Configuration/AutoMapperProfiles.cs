
using AutoMapper;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ArtistAddEditVM, Artist>();
            CreateMap<BuyTicketVM, Ticket>();
        }
    }
}
