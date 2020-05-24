using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class LiftTariffRepository: Repository<LiftTariff>, ILiftTariffRepository
    {
        public LiftTariffRepository(ERDContainer dbContext) : base(dbContext) { }
        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }

        public LiftTariff GetLatestLiftTariff(int liftId)
        {
            return ERDContainer.Set<LiftTariff>().Where(lift=>lift.SkiLiftID==liftId).OrderByDescending(lift => lift.BeginDate).FirstOrDefault();
        }

        public IEnumerable<LiftTariff> GetLiftTariffHistory(int liftId)
        {
            return ERDContainer.Set<LiftTariff>().Where(lift => lift.SkiLiftID == liftId).OrderByDescending(lift => lift.BeginDate);
        }
    }
}
