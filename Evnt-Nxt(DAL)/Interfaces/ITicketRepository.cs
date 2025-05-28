using Evnt_Nxt_DAL_.DTO;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface ITicketRepository
    {
        public void AddTicketToUser(TicketDTO ticket, int quantity);
        public void DecreaseAvailableTickets(int eventTicketID, int quantity);
    }
}
