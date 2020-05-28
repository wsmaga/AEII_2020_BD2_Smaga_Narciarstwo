using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class LiftUsageHistoryRepository : Repository<LiftUsageHistory>, ILiftUsageHistoryRepository
    {
        public LiftUsageHistoryRepository(ERDContainer dbContext) : base(dbContext) { }

        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }
        public IEnumerable<LiftUsageHistory> GetLiftUsageHistory(int liftId)
        {
            return ERDContainer.Set<LiftUsageHistory>()
                .Where(lift => lift.SkiLiftID == liftId)
                .OrderByDescending(lift => lift.Date);
        }

    }
}
