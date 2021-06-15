using System;
using System.Collections.Generic;
using System.Text;

namespace PoorChase.Data
{
    /// <summary>
    /// Base class for specified data entity repository
    /// </summary>
    /// <typeparam name="TEntity">Type of entity to be handled by the derived repository</typeparam>
    public abstract class BaseRepository<TEntity> : IDataRepository<TEntity>
    {
        protected readonly DataContext _context;

        public BaseRepository()
        {
            _context = new DataContext();
        }

        public abstract void Add(TEntity entity);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract TEntity GetById(int id);

        public abstract void Remove(TEntity entity);

        public abstract void Update(TEntity entity);
    }
}
