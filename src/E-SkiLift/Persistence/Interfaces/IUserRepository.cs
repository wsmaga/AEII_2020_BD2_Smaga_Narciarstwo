using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence
{
    interface IUserRepository: IRepository<User>
    {
        User GetUserByCredentials(string login, string password);
    }
}
