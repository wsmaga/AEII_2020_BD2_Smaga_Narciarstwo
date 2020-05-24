using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class SkiLiftScheduleRepository: Repository<SkiLiftSchedule>, ISkiLiftScheduleRepository
    {
        public SkiLiftScheduleRepository(ERDContainer dbContext) : base(dbContext) { }
        
        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }

        public IEnumerable<SkiLiftSchedule> GetFullLiftSchedule(int liftId)
        {
            return ERDContainer.Set<SkiLiftSchedule>().Where(lift => lift.LiftID == liftId);
        }

        public SkiLiftSchedule GetLiftSchedule(int liftId, byte dayOfWeek)
        {
            return ERDContainer.Set<SkiLiftSchedule>().Where(lift => lift.LiftID == liftId && lift.DayOfTheWeek==dayOfWeek).FirstOrDefault();
        }
    }
}
