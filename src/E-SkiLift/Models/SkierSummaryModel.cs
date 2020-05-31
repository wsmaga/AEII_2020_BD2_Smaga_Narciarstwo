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
        private List<LiftID> _liftIdList = new List<LiftID>();

        public SkierSummaryModel(int ticketID)
        {
            LiftUsageHistory[] liftUsageHistory = uow.LiftUsageHistory.GetLiftUsageHistoryByTicketID(ticketID).ToArray();

            TicketID = ticketID;

            SummaryEntryList = new List<SummaryEntry>();
            _liftIdList.Add(new LiftID("All"));
            foreach(LiftUsageHistory luh in liftUsageHistory)
            {
                SummaryEntryList.Add(new SummaryEntry(luh.Date.ToString(), luh.SkiLiftID));
                if (!_liftIdList.Contains(new LiftID(luh.SkiLiftID.ToString())))
                    _liftIdList.Add(new LiftID(luh.SkiLiftID.ToString()));
            }
        }

        public SkierSummaryModel(int ticketID, int liftID)
        {
            LiftUsageHistory[] liftUsageHistory = uow.LiftUsageHistory.GetLiftUsageHistoryByLiftIDAndTicketID(liftID, ticketID).ToArray();
            LiftUsageHistory[] liftUsageHistoryLiftIDs = uow.LiftUsageHistory.GetLiftUsageHistoryByTicketID(ticketID).ToArray();

            TicketID = ticketID;

            SummaryEntryList = new List<SummaryEntry>();
            foreach(LiftUsageHistory luh in liftUsageHistory)
            {
                SummaryEntryList.Add(new SummaryEntry(luh.Date.ToString(), luh.SkiLiftID));
            }

            _liftIdList.Add(new LiftID("All"));
            foreach(LiftUsageHistory luhID in liftUsageHistoryLiftIDs)
            {
                if (!_liftIdList.Contains(new LiftID(luhID.SkiLiftID.ToString())))
                    _liftIdList.Add(new LiftID(luhID.SkiLiftID.ToString()));
            }
        }

        public int TicketID { get => _ticketID; set => _ticketID = value; }
        public List<SummaryEntry> SummaryEntryList { get => _summaryEntryList; set => _summaryEntryList = value; }
        public List<LiftID> LiftIdList { get => _liftIdList; set => _liftIdList = value; }

        public struct LiftID
        {
            public LiftID(String id)
            {
                ID = id;
            }
            public String ID { get; }
        }

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
