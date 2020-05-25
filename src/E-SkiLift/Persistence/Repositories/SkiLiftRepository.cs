using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class SkiLiftRepository: Repository<SkiLift>, ISkiLiftRepository
    {
        public SkiLiftRepository(ERDContainer dbContext): base(dbContext) { }

        public void OpenLift(int id)
        {
            SkiLift lift = ERDContainer.Set<SkiLift>().Find(id);
            if (lift != null)
                lift.IsOpen = true;
            
        }
        public void CloseLift(int id)
        {
            SkiLift lift = ERDContainer.Set<SkiLift>().Find(id);
            if (lift != null)
                lift.IsOpen = false;
        }
        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }
    }
}
