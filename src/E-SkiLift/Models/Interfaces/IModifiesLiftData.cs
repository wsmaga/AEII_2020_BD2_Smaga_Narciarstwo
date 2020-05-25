using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models.Interfaces
{
    public interface IModifiesLiftData
    {
        bool SkiLiftExists(int id);
        ScheduleContainer GetCurrentSkiLiftSchedule(int id);
        int GetCurrentLiftPointCost(int id);
        bool UpdateLiftTariff(int id, int newPointCost, System.DateTime newBeginDate);
        bool UpdateSkiLiftSchedule(int id, byte dayOfWeek, string newBeginHour, string newEndHour, DateTime newBeginDate);
    }
}
