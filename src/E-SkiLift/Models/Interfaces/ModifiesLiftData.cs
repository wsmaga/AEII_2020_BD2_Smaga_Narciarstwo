using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models.Interfaces
{
    public class ModifiesLiftData: User, IModifiesLiftData
    {
        protected readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());
        public bool SkiLiftExists(int id)
        {
            return uow.SkiLifts.Get(id) != null;
        }
        public int GetCurrentLiftPointCost(int id)
        {
            LiftTariff tariff = uow.LiftTariffs.GetLatestLiftTariff(id);
            return tariff?.PointCost ?? 0;
        }
        public bool UpdateLiftTariff(int id, int newPointCost, System.DateTime newBeginDate)
        {
            LiftTariff oldTariff = uow.LiftTariffs.GetLatestLiftTariff(id);
            if (oldTariff != null)
            {
                oldTariff.EndDate = newBeginDate;
                uow.LiftTariffs.Add(new LiftTariff { SkiLiftID = id, BeginDate = newBeginDate, PointCost = newPointCost });
                return uow.Complete() == 2;
            }
            else
                return false;
        }


        public ScheduleContainer GetCurrentSkiLiftSchedule(int id)
        {
            SkiLiftSchedule[] schedule = uow.SkiLiftSchedules.GetCurrentFullLiftSchedule(id).ToArray();
            if (schedule?.Length == 7)
            {
                string[] beginHours = new string[] {
                schedule[0].BeginHour,
                schedule[1].BeginHour,
                schedule[2].BeginHour,
                schedule[3].BeginHour,
                schedule[4].BeginHour,
                schedule[5].BeginHour,
                schedule[6].BeginHour};
                string[] endHours = new string[] {
                schedule[0].EndHour,
                schedule[1].EndHour,
                schedule[2].EndHour,
                schedule[3].EndHour,
                schedule[4].EndHour,
                schedule[5].EndHour,
                schedule[6].EndHour};
                return new ScheduleContainer() { BeginHours = beginHours, EndHours = endHours };
            }
            else
                return null;
        }

        public bool UpdateSkiLiftSchedule(int id, byte dayOfWeek, string newBeginHour, string newEndHour, DateTime newBeginDate)
        {
            SkiLiftSchedule schedule=uow.SkiLiftSchedules.GetCurrentDayLiftSchedule(id,dayOfWeek);
            if (schedule != null)
            {
                schedule.EndDate = newBeginDate;
                uow.SkiLiftSchedules.Add(new SkiLiftSchedule { 
                    LiftID = id, 
                    DayOfTheWeek = dayOfWeek, 
                    BeginHour = newBeginHour, 
                    EndHour = newEndHour, 
                    BeginDate = newBeginDate, 
                    EndDate = null });
                return uow.Complete() == 2;
            }
            else
                return false;
        }
    }
}
