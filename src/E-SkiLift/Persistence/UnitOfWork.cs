
using E_SkiLift.Persistence;
using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Repository
{
    class UnitOfWork:IDisposable
    {
        private readonly ERDContainer context;
        public UnitOfWork(ERDContainer _context)
        {
            context = _context;
            Users = new UserRepository(context);
        }
        public IUserRepository Users { get; private set; }
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
