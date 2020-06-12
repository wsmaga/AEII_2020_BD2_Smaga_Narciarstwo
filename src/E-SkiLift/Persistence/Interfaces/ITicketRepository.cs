using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        int GetAmountOfTicketsSold(DateTime from, DateTime to);

        IEnumerable<Ticket> GetTicketByID(int ID);
    }
}
