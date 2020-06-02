using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_SkiLift.Models
{
    public class Cashier: User
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());

        public bool SellPointTicket(int points)
        {
            TicketTariff tariff = uow.TicketTariff.GetLatestTicketTariff();
            DateTime now = DateTime.Now;
            double price = Math.Round(points * tariff.PointPrice, 2);
            uow.PointTickets.Add(new PointTicket { Points = points, IsValid = true, DateAdded = now, PriceSold = price });
            return uow.Complete() == 1;
        }

        public bool SellSkiPass(DateTime expirationDate)
        {
            TicketTariff tariff = uow.TicketTariff.GetLatestTicketTariff();
            DateTime now = DateTime.Now;
            TimeSpan ts = expirationDate - now;
            double price = Math.Round(tariff.HourPrice * ts.TotalHours, 2);
            uow.SkiPasses.Add(new SkiPass { IsValid = true, ExpirationTime = expirationDate, DateAdded = now, PriceSold = price });
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
