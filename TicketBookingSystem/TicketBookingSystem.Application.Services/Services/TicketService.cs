using AutoMapper;
using TicketBookingSystem.Application.Abstraction;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Shared.Application;
using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Application.Services
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
