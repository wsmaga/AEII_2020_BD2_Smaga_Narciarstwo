using E_SkiLift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Models
{
    class DeleteLiftModel
    {
        private readonly UnitOfWork uow = new UnitOfWork(new ERDContainer());
        private List<Lifts> _liftsList;

        public DeleteLiftModel()
        {
            SkiLift[] liftsArray = uow.SkiLifts.GetAll().ToArray();

            LiftsList = new List<Lifts>();
            foreach(SkiLift lift in liftsArray)
            {
                LiftsList.Add(new Lifts(lift.ID));
            }
        }

        public List<Lifts> LiftsList { get => _liftsList; set => _liftsList = value; }

        public class Lifts
        {
            private int _liftID;

            public Lifts(int ID)
            {
                LiftID = ID;
            }

            public int LiftID { get => _liftID; set => _liftID = value; }
        }
    }
}
