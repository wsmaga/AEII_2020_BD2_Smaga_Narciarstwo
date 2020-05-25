using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class PointTicketRepository : Repository<PointTicket>, IPointTicketRepository
    {
        public PointTicketRepository(ERDContainer dbContext) :
            base(dbContext)
        { }

        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }
    }
}
