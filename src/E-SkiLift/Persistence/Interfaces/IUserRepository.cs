using E_SkiLift.Models;
using E_SkiLift.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.DAO
{
    interface IUserRepository: IRepository<User>
    {
        User GetUserByCredentials(string login, string password);
    }
}
