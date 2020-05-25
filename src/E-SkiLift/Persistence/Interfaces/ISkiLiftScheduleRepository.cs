using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Interfaces
{
    interface ISkiLiftScheduleRepository: IRepository<SkiLiftSchedule>
    {
        IEnumerable<SkiLiftSchedule> GetCurrentFullLiftSchedule(int liftId);
        SkiLiftSchedule GetCurrentDayLiftSchedule(int liftId, byte dayOfWeek);
        IEnumerable<SkiLiftSchedule> GetFullLiftScheduleHistory(int liftId);
    }
}
