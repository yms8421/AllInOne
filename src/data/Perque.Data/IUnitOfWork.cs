using Perque.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Perque.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T: EntityBase;
        int SaveChanges();
    }
}
