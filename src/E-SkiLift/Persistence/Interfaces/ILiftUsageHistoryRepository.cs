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
        IEnumerable<LiftUsageHistory> GetLiftUsageHistory(int liftId);
    }
}
