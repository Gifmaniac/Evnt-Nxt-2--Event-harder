using Evnt_Nxt_DAL_.DTO;
using EvntNxt.DTO;
using EvntNxtDTO;

namespace Evnt_Nxt_DAL_.Interfaces
{
    public interface ITicketRepository
    {
        public void AddTicketToUser(TicketDTO ticket, int quantity);
        public void DecreaseAvailableTickets(int eventTicketID, int quantity);

        public List<UserProfileTicketDTO> GetTicketByUserID(int userID);
    }
}
