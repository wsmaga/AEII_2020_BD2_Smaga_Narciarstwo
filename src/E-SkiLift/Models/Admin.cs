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
                uow.Users.Add(new User {ID=0,Login=_login,Password=_password,Name=_name,UserType=(int)_type });
                return uow.Complete() == 1;
            }
        }
    }
}
