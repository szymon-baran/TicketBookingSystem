using AutoMapper;
using TicketBookingSystem.Server.Application.Abstraction;
using TicketBookingSystem.Server.Data.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Dictionaries;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservedTicketVM>> GetReservedTicketsVMAsync(string userId) 
        { 
            List<Ticket> tickets = await _ticketRepository.GetTicketsAsync(userId);
            return tickets.Select(x => new ReservedTicketVM()
            {
                Id = x.Id,
                TicketTypeName = x.TicketType.GetDescription(),
                OwnerFirstName = x.OwnerFirstName,
                OwnerLastName = x.OwnerLastName,
                IsSittingSpot = x.IsSittingSpot,
                EventName = x.Event.Name,
                EventTime = x.Event.EventTime
            }).ToList();
        }

        public async Task<int> BuyTicket(BuyOperationVM model, string userId)
        {
            int counterStanding = 0;
            int counterSitting = 0;
            List<Ticket> tickets = new();

            foreach (var ticketModel in model.Tickets)
            {
                if (ticketModel.IsSittingSpot)
                    counterSitting++;
                else
                    counterStanding++;

                Ticket ticket = _mapper.Map<Ticket>(ticketModel);
                ticket.ApplicationUserId = userId;
                ticket.EventId = model.EventId;
                tickets.Add(ticket);
            }

            _ticketRepository.AddRange(tickets);
            await _ticketRepository.SaveAsync();

            await _eventRepository.SynchronizeTicketsNums(model.EventId, counterSitting, counterStanding);

            return counterStanding + counterSitting;
        }
    }
}
