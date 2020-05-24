using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Interfaces
{
    interface ISkiLiftRepository: IRepository<SkiLift>
    {
        void CloseLift(int  id);
        void OpenLift(int  id);
    }
}
