using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoorChase.Data
{
    /// <summary>
    /// Holder of general entity-data repository methods
    /// </summary>
    /// <typeparam name="TEntity">Entity type to be handled</typeparam>
    public interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
