
using E_SkiLift.Persistence;
using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_SkiLift.Persistence.Interfaces;
using E_SkiLift.Persistence.Repositories;

namespace E_SkiLift.Repository
{
    public class UnitOfWork:IDisposable
    {
        private readonly ERDContainer context;
        public UnitOfWork(ERDContainer _context)
        {
            context = _context;
            Users = new UserRepository(context);
            SkiLifts = new SkiLiftRepository(context);
            LiftTariffs = new LiftTariffRepository(context);
            SkiLiftSchedules = new SkiLiftScheduleRepository(context);
            SkiPasses = new SkiPassRepository(context);
            PointTickets = new PointTicketRepository(context);
            Tickets = new TicketRepository(context);
            TicketTariff = new TicketTariffRepository(context);
            LiftUsageHistory = new LiftUsageHistoryRepository(context);
        }
        public IUserRepository Users { get; private set; }
        public ISkiLiftRepository SkiLifts { get; private set; }
        public ILiftTariffRepository LiftTariffs { get; private set; }
        public ISkiLiftScheduleRepository SkiLiftSchedules { get; private set; }
        public ISkiPassRepository SkiPasses { get; private set; }
        public IPointTicketRepository PointTickets { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public ITicketTariffRepository TicketTariff { get; private set; }
        public ILiftUsageHistoryRepository LiftUsageHistory { get; private set; }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
