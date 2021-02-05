using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Teams.Data;

namespace CheckQueuedPrograms
{
    public class ApplicationDbContextFactory
    {
        public static IApplicationDbContext GetContext()
        {
            var directories = Directory.GetDirectories(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent
    (Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName);
            var directory = (from dir in directories
                             where dir.Contains("Teams")
                             where !dir.Contains(".")
                             select dir).First();
            Console.WriteLine(directory);
            var builder = new ConfigurationBuilder().SetBasePath(directory).AddJsonFile("appsettings.Development.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
