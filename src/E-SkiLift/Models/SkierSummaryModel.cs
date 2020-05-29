using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models
{
    public class SkierSummaryModel
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());
        private int _ticketID;
        private List<SummaryEntry> _summaryEntryList;

        public SkierSummaryModel(int ticketID)
        {
            LiftUsageHistory[] liftUsageHistory = uow.LiftUsageHistory.GetLiftUsageHistoryByTicketID(ticketID).ToArray();

            TicketID = ticketID;

            SummaryEntryList = new List<SummaryEntry>();

            for (int i = 0; i < liftUsageHistory.Length; i++)
                SummaryEntryList.Add(new SummaryEntry(liftUsageHistory[i].Date.ToString(), liftUsageHistory[i].SkiLiftID));
        }

        public int TicketID { get => _ticketID; set => _ticketID = value; }
        public List<SummaryEntry> SummaryEntryList { get => _summaryEntryList; set => _summaryEntryList = value; }

        public class SummaryEntry
        {
            private String _date;
            private int _liftID;

            public SummaryEntry(string date, int liftId)
            {
                Date = date;
                LiftId = liftId;
            }

            public string Date { get => _date; set => _date = value; }
            public int LiftId { get => _liftID; set => _liftID = value; }
        }
    }
}
