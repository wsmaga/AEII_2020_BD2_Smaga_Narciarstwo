using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models
{
    class Gate
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());

        public bool Validate(int ticketID, int liftID)
        {
            Ticket ticket = uow.Tickets.Get(ticketID);
            SkiLift lift = uow.SkiLifts.Get(liftID);

            if(ticket == null || lift == null)
                return false;
            else
            {
                LiftUsageHistory luh = new LiftUsageHistory();
                luh.Date = DateTime.Now;
                luh.SkiLiftID = liftID;
                luh.TicketID = ticketID;

                uow.LiftUsageHistory.Add(luh);
                return uow.Complete() == 1;
            }
        }
    }
}
