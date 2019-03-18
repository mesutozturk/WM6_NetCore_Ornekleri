using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kuzey.DAL;
using Kuzey.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kuzey.BLL.Repository.Abstracts
{
    public abstract class RepositoryBase<T, TId> : IRepository<T, TId> where T : BaseEntity<TId>
    {
        private readonly MyContext DbContext;
        private readonly DbSet<T> DbObject;

        internal RepositoryBase(MyContext dbContext)
        {
            DbContext = dbContext;
            DbObject = DbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return DbObject.ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return DbObject.Where(predicate).ToList();
        }

        public List<T> GetAll(params string[] includes)
        {
            foreach (var inc in includes)
            {
                DbObject.Include(inc);
            }
            return DbObject.ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate, params string[] includes)
        {
            foreach (var inc in includes)
            {
                DbObject.Include(inc);
            }
            return DbObject.Where(predicate).ToList();
        }

        public T GetById(TId id)
        {
            return DbObject.Find(id);
        }

        public virtual void Insert(T entity)
        {
            DbObject.Add(entity);
            DbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbObject.Remove(entity);
            DbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbObject.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            //entity.UpdatedDate = DateTime.Now;
            this.Save();
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public IQueryable<T> Queryable()
        {
            return DbObject.AsQueryable();
        }

        public IQueryable<T> Queryable(params string[] includes)
        {
            foreach (var inc in includes)
            {
                DbObject.Include(inc);
            }
            return DbObject.AsQueryable<T>();
        }
    }
}
