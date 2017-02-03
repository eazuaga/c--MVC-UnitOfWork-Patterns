using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UoW.App_Start
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<TEntity> _dbset;

        public GenericRepository(MyDbContext context)
        {
            this._context = context;
            this._dbset = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            this._dbset.Add(entity);
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await this._dbset.FindAsync(keyValues);
        }
        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return this._dbset.SqlQuery(query, parameters).AsQueryable();
        }
        public void Update(TEntity entity)
        {
            this._dbset.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            if (this._context.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }
        public async Task Delete(params object[] id)
        {
            TEntity entity = await this.FindAsync(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }
        public IQueryable<TEntity> Queryable()
        {
            return _dbset;
        }
    }
}