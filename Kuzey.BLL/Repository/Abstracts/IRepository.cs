using System;
using System.Collections.Generic;
using System.Linq;
using Kuzey.Models.Entities;

namespace Kuzey.BLL.Repository.Abstracts
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        List<T> GetAll(params string[] includes);
        List<T> GetAll(Func<T, bool> predicate, params string[] includes);
        T GetById(TId id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
        IQueryable<T> Queryable();
        IQueryable<T> Queryable(params string[] includes);
    }
}
