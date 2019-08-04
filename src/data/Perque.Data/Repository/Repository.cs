using Microsoft.EntityFrameworkCore;
using Perque.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Perque.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private DbSet<T> dbSet;
        public Repository(DbContext context)
        {
            dbSet = context.Set<T>();
        }
        
        #region IQueryable
        public Type ElementType => dbSet.AsQueryable().ElementType;

        public Expression Expression => dbSet.AsQueryable().Expression;

        public IQueryProvider Provider => dbSet.AsQueryable().Provider;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return dbSet.AsQueryable().GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return dbSet.AsQueryable().GetEnumerator();
        }
        #endregion

        #region IRepository
        public void Add(T item)
        {
            item.CreatedDate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            dbSet.Remove(item);
        }

        public T Get(int id)
        {
            return dbSet.Single(i => i.Id == id);
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        } 
        #endregion
    }
}
