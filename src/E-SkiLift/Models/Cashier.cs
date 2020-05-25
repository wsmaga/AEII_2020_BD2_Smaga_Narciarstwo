using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_SkiLift.Models
{
    class Cashier: User
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());

        public bool SellPointTicket(int points)
        {
            uow.PointTickets.Add(new PointTicket { Points = points, IsValid = true });
            return uow.Complete() == 1;
        }

        public bool SellSkiPass(DateTime expirationDate)
        {
            uow.SkiPasses.Add(new SkiPass { IsValid = true, ExpirationTime = expirationDate });
            return uow.Complete() == 1;
        }

        public bool RefundTicket(int id)
        {
            Ticket temp = uow.Tickets.Get(id);
            if (temp != null)
            {
                uow.Tickets.Remove(temp);
                return uow.Complete() == 1;
            }
            else
                return false;
            
        }


    }
}
