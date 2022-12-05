using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Application
{
    public class BuyTicketVM
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public long OwnerPESEL { get; set; }
        public TicketType TicketType { get; set; } = TicketType.Free;
        public bool IsSittingSpot { get; set; } = false;
        public double Price { get => GetPriceForTicket(); }
        private double SittingTicketPrice { get; set; }
        private double StandingTicketPrice { get; set; }
        private double ReducedDiscount { get; set; }
        
        public void SetPrices(double sittingTicketPrice, double standingTicketPrice, double reducedDiscount)
        {
            SittingTicketPrice = sittingTicketPrice;
            StandingTicketPrice = standingTicketPrice;
            ReducedDiscount = reducedDiscount;
        }
        private double GetPriceForTicket()
        {
            return TicketType switch
            {
                TicketType.Normal => IsSittingSpot ? StandingTicketPrice : SittingTicketPrice,
                TicketType.Reduced => ReducedDiscount * (IsSittingSpot ? StandingTicketPrice : SittingTicketPrice),
                TicketType.Free => 0
            };
        }
    }
}
