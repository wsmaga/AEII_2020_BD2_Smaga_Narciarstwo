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

        public IEnumerable<SkiLiftSchedule> GetCurrentFullLiftSchedule(int liftId)
        {
            return ERDContainer.Set<SkiLiftSchedule>().Where(sch => sch.LiftID == liftId && sch.EndDate==null).OrderBy(sch => sch.DayOfTheWeek);
        }

        public SkiLiftSchedule GetCurrentDayLiftSchedule(int liftId, byte dayOfWeek)
        {
            return ERDContainer.Set<SkiLiftSchedule>().Where(sch => sch.LiftID == liftId && sch.DayOfTheWeek==dayOfWeek && sch.EndDate==null).FirstOrDefault();
        }

        public IEnumerable<SkiLiftSchedule> GetFullLiftScheduleHistory(int liftId)
        {
            return ERDContainer.Set<SkiLiftSchedule>().Where(sch => sch.LiftID == liftId).OrderBy(sch => sch.DayOfTheWeek).OrderBy(sch=> sch.EndDate);
        }
    }
}
