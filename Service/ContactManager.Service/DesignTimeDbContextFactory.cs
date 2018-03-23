using ContactManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Service
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContactManagerContextSql>
    {
        public ContactManagerContextSql CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ContactManagerContextSql>();
            var connectionString = configuration["Data:DefaultConnection:ConnectionString"];
            builder.UseSqlServer(connectionString);
            return new ContactManagerContextSql(configuration);
        }
    }
}
