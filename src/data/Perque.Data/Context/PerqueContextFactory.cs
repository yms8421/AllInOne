using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Perque.Contracts;
using System.IO;

namespace Perque.Data.Context
{
    public class PerqueContextFactory : IDesignTimeDbContextFactory<PerqueContext>
    {
        public PerqueContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = config.GetSection("ConnectionStrings:MainDatabase").Value;

            var optionsBuilder = new DbContextOptionsBuilder<PerqueContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new PerqueContext(optionsBuilder.Options);
        }
    }
}
