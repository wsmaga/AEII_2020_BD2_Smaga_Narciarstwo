using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using E_SkiLift.Repository;
using E_SkiLift.Utility;

namespace E_SkiLift.Models
{
    class Admin: User
    {
        public static bool AddUser(UserType _type, string _name, string _login, string _password)
        {
            /*            var user = new {Type = _type, Name = _name, Login = _login, Password = _password };

                        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnHelper.ConnStringValue("SkiLiftDB")))
                        {
                            connection.Execute("dbo.AddUser @Name, @Type, @Login, @Password", user);
                            connection.Query<User>("select * from Users").ToList();
                        }*/
            
            using(UnitOfWork uow=new UnitOfWork(new ERDContainer()))
            {
                List<User> temp = uow.Users.GetAll().ToList();
                uow.Users.Add(new User {ID=0,Login=_login,Password=_password,Name=_name,UserType=(int)_type });
                uow.Complete();
                List<User> temp2 = uow.Users.GetAll().ToList();


            }

            return true;
        }
    }
}
