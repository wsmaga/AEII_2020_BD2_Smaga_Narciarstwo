using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_SkiLift.Models
{
    public enum UserType { Admin = 0, Owner = 1, Cashier = 2 }
    partial class User
    { 
        public static User SignIn(string login, string password)
        {
            using (UnitOfWork uow=new UnitOfWork(new ERDContainer()))
            {
                return uow.Users.GetUserByCredentials(login, password);
            }
        }
        public void SignOut()
        {

        }
    }
}
