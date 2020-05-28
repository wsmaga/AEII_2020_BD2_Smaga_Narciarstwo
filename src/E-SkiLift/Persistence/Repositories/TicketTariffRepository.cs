using E_SkiLift.Models;
using E_SkiLift.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Repositories
{
    class TicketTariffRepository : Repository<TicketTariff>, ITicketTariffRepository {

        public TicketTariffRepository(ERDContainer dbContext) : base(dbContext) { }
        public ERDContainer ERDContainer { get { return dbContext as ERDContainer; } }

        TicketTariff GetLatestTicketTariff()
        {
            return ERDContainer.Set<TicketTariff>().OrderByDescending(ticket=>ticket.BeginDate).FirstOrDefault();
        }
        IEnumerable<TicketTariff> GetTicketTariffHistory()
        {
            return ERDContainer.Set<TicketTariff>().OrderByDescending(ticket => ticket.BeginDate);
        }

        IEnumerable<TicketTariff> GetTicketTariffHistory(DateTime beginDate, DateTime endDate)
        {
            return ERDContainer.Set<TicketTariff>().Where(ticket=>ticket.BeginDate > beginDate && ticket.EndDate < endDate).OrderByDescending(ticket => ticket.BeginDate);
        }
    }
}
