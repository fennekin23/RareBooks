using System.Collections.Generic;
using System.Linq;
using Rb.Data.Entities;

namespace Rb.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Items { get; }

        void Add(T entity);
        void Add(IEnumerable<T> entities);
        T GetById(int id);
        T GetById(int id, int secondaryId);
        void Remove(T entity);
        void Update(T entity);
    }
}