using Microsoft.EntityFrameworkCore;
using Perque.Entities;

namespace Perque.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public IRepository<T> GetRepository<T>() where T : EntityBase
        {
            //TODO: tightly coupled'dan çıkar
            return new Repository<T>(context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
