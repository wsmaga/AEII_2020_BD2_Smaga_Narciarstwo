using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.Persistence
{
    public interface IRepository <TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
