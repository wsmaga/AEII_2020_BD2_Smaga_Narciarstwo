using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_SkiLift.Repository;

namespace E_SkiLift.Models
{
    class Admin: User
    {

        public static bool AddUser(UserType _type, string _name, string _login, string _password)
        {
            using(UnitOfWork uow=new UnitOfWork(new ERDContainer()))
            {
                uow.Users.Add(new User {Login=_login,Password=_password,Name=_name,UserType=(int)_type });
                return uow.Complete() == 1;
            }
        }
        public static bool RemoveUser(int _id)
        {
            using(UnitOfWork uow=new UnitOfWork(new ERDContainer()))
            {
                uow.Users.Remove(uow.Users.Get(_id));
                return uow.Complete() == 1;
            }
        }
        public static bool AddSkiLift(System.DateTime BeginDate, System.DateTime EndDate, int TarPointCost, string[] SchBeginHours, string[] SchEndHours, bool _isOpen = true)
        {
            using (UnitOfWork uow = new UnitOfWork(new ERDContainer()))
            {
                SkiLift newLift=uow.SkiLifts.Add(new SkiLift { IsOpen = _isOpen });
                uow.LiftTariffs.Add(new LiftTariff() { SkiLiftID = newLift.ID, BeginDate = BeginDate, EndDate = EndDate, PointCost = TarPointCost });
                for (byte i = 0; i < 7; i++)
                    uow.SkiLiftSchedules.Add(new SkiLiftSchedule { LiftID=newLift.ID,DayOfTheWeek = i, BeginHour=SchBeginHours[i],EndHour=SchEndHours[i],BeginDate=BeginDate, EndDate=EndDate});
                return uow.Complete() == 1;
            }
        }
        public static bool RemoveSkiLift(int _id)
        {
            using (UnitOfWork uow = new UnitOfWork(new ERDContainer()))
            {
                uow.SkiLifts.Remove(uow.SkiLifts.Get(_id));
                return uow.Complete() == 1;
            }
        }
        public static bool OpenOrCloseSkiLift(int id, bool state)
        {
            using (UnitOfWork uow = new UnitOfWork(new ERDContainer()))
            {
                if (state)
                    uow.SkiLifts.OpenLift(id);
                else
                    uow.SkiLifts.CloseLift(id);
                return uow.Complete() == 1;
            }
        }
    }
}
