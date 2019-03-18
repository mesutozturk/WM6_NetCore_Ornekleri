using System;
using System.Collections.Generic;
using System.Linq;
using Kuzey.Models.Entities;

namespace Kuzey.BLL.Repository.Abstracts
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, bool> predicate);
        T GetById(TId id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
