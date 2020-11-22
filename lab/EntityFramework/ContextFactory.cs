using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace lab.EntityFramework
{
    public class ContextFactory
    {
        public static DataContext Create(string connectionName)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString(connectionName);
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;

            return DataContext.GetContext(options);
        }
    }
}
