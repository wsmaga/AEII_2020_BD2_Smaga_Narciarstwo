using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_SkiLift.DAO
{
    class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }
        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
