using E_SkiLift.Models.Interfaces;
using E_SkiLift.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace E_SkiLift.Models
{
    public class Owner : ModifiesLiftData
    {
        private double _totalSales;
        private int _totalTicketsSold;
        private List<LiftUsage> _liftUsageList;

        public void ShowTotalSales(DateTime from, DateTime to)
        {
            IEnumerable<Ticket> tickets = uow.Tickets.GetAll().Where(ticket => ticket.DateAdded >= from && ticket.DateAdded <= to);
            double totalSales = 0;
            foreach(Ticket ticket in tickets)
            {
                totalSales += ticket.PriceSold;
            }
            TotalSales = Math.Round(totalSales, 2);
        }

        public void ShowTotalTicketsSold(DateTime from, DateTime to)
        {
            int ticketsSold = uow.Tickets.GetAmountOfTicketsSold(from, to);
            TotalTicketsSold = ticketsSold;
        }

        public void ShowLiftUsage(DateTime from, DateTime to)
        {
            IEnumerable<LiftUsageHistory> liftUsages = uow.LiftUsageHistory.GetLiftUsageHistoryByDate(from, to);
            LiftUsageList = new List<LiftUsage>();
            foreach(LiftUsageHistory liftUsage in liftUsages)
            {
                LiftUsage lift = LiftUsageList.Find(delegate (LiftUsage l) { return l.LiftId == liftUsage.SkiLiftID; }) ;
                if(lift != null)
                {
                    lift.Uses += 1;
                }
                else
                {
                    LiftUsageList.Add(new LiftUsage(1, liftUsage.SkiLiftID));
                }
            }
        }

        public double TotalSales { get => _totalSales; set => _totalSales = value; }
        public int TotalTicketsSold { get => _totalTicketsSold; set => _totalTicketsSold = value; }
        public List<LiftUsage> LiftUsageList { get => _liftUsageList; set => _liftUsageList = value; }
        public class LiftUsage
        {
            private int _uses;
            private int _liftID;

            public LiftUsage(int uses, int liftId)
            {
                Uses = uses;
                LiftId = liftId;
            }
            public int Uses { get => _uses; set => _uses = value; }
            public int LiftId { get => _liftID; set => _liftID = value; }
        }
    }
}
