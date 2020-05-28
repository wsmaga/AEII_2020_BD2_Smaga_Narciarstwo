using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence.Interfaces
{
    public interface ITicketTariffRepository : IRepository<TicketTariff>
    {

        TicketTariff GetLatestTicketTariff();
        IEnumerable<TicketTariff> GetTicketTariffHistory();

        IEnumerable<TicketTariff> GetTicketTariffHistory(DateTime beginDate, DateTime endDate);

    }
}
