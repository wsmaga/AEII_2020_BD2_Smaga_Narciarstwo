using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_SkiLift.Models.Interfaces;
using E_SkiLift.Repository;

namespace E_SkiLift.Models
{
    public class Admin: ModifiesLiftData
    {
        public bool AddUser(UserType _type, string _name, string _login, string _password)
        {
            if (uow.Users.GetUserByLogin(_login)==null)
            {
                uow.Users.Add(new User { Login = _login, Password = _password, Name = _name, UserType = (int)_type });
                return uow.Complete() == 1;
            }
            else
                return false;
        }
        public bool RemoveUser(int _id)
        {
            uow.Users.Remove(uow.Users.Get(_id));
            return uow.Complete() == 1;
        }
        public  bool AddSkiLift(System.DateTime BeginDate, int TarPointCost, string[] SchBeginHours, string[] SchEndHours, bool _isOpen = true)
        {
            SkiLift newLift=uow.SkiLifts.Add(new SkiLift { IsOpen = _isOpen });
            uow.LiftTariffs.Add(new LiftTariff() { SkiLiftID = newLift.ID, BeginDate = BeginDate, EndDate = null, PointCost = TarPointCost });
            for (byte i = 0; i < 7; i++)
                uow.SkiLiftSchedules.Add(new SkiLiftSchedule { LiftID=newLift.ID,DayOfTheWeek = i, BeginHour=SchBeginHours[i],EndHour=SchEndHours[i],BeginDate=BeginDate, EndDate=null});
            return uow.Complete() == 9;
        }
        public bool RemoveSkiLift(int _id)
        {
            int noOfRecords = 1 
                + uow.SkiLiftSchedules.GetFullLiftScheduleHistory(_id).ToList().Count
                + uow.LiftTariffs.GetLiftTariffHistory(_id).ToList().Count;
            uow.SkiLifts.Remove(uow.SkiLifts.Get(_id));
            return uow.Complete() == noOfRecords;
        }

        public bool OpenOrCloseSkiLift(int id, bool state)
        {
            if (state)
                uow.SkiLifts.OpenLift(id);
            else
                uow.SkiLifts.CloseLift(id);
            return uow.Complete() == 1;
        }
        
        public Nullable<bool> LiftIsOpen(int id)
        {
            return uow.SkiLifts.Get(id)?.IsOpen;
        }
    }
}
