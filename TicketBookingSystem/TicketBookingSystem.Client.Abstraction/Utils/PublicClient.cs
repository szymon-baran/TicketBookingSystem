namespace TicketBookingSystem.Client.Abstraction.Utils
{
    public class PublicClient
    {
        public HttpClient Client { get; }

        public PublicClient(HttpClient client)
        {
            Client = client;
        }
    }
}
