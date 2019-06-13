using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using LamdaForums.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace LamdaForums
{
    class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //Added this to map the web layer to the data layer during app start up
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=LambdaForums2.Dev;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
