using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Interfaces
{
    public interface ILiftUsageHistoryRepository : IRepository<LiftUsageHistory>
    {
        IEnumerable<LiftUsageHistory> GetLiftUsageHistoryByLiftID(int liftID);

        IEnumerable<LiftUsageHistory> GetLiftUsageHistoryByTicketID(int ticketID);

        IEnumerable<LiftUsageHistory> GetLiftUsageHistoryByLiftIDAndTicketID(int liftID, int ticketID);

        IEnumerable<LiftUsageHistory> GetLiftUsageHistoryByDate(DateTime from, DateTime to);
    }
}
