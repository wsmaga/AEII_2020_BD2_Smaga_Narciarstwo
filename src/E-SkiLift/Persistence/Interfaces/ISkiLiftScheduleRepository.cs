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
        IEnumerable<SkiLiftSchedule> GetFullLiftSchedule(int liftId);
        SkiLiftSchedule GetLiftSchedule(int liftId, byte dayOfWeek);
    }
}
