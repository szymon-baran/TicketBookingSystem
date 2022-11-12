﻿using AutoMapper;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddArtistVM, Artist>();
            CreateMap<EditArtistVM, Artist>();
        }
    }
}