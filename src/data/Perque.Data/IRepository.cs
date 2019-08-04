using Perque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perque.Data
{
    public interface IRepository<T> : IQueryable<T> where T : EntityBase
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T Get(int id);
    }
}
