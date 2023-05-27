using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OMR_Service.EF
{
    public class OMRDBContextFactory : IDesignTimeDbContextFactory<OMRDBContext>
    {
        public OMRDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("OMRDB");

            var optionsBuilder = new DbContextOptionsBuilder<OMRDBContext>();
            optionsBuilder.UseSqlServer(connectionString);


            return new OMRDBContext(optionsBuilder.Options);
        }
    }
}