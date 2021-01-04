using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using Teams.Data;
using Teams.Data.CodeTester;
using Teams.Data.Repositories;

namespace QueuedProgramsChecker
{
    public class Program
    {
        private static IApplicationDbContext _context;
        static void Main(string[] args)
        {
            try
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
                _context = new ApplicationDbContext(optionsBuilder.Options);
                TimerCallback callback = CheckQueue;
                Timer timer = new Timer(callback, null, 0, 1000);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // debug
                Thread.Sleep(10000); // debug
                throw;
            }
        }
        static async void CheckQueue(object obj)
        {
            foreach (var program in _context.QueuedPrograms)
            {
                if (program.Status == 0) // unchecked
                {
                    program.StartChecking();
                    CodeTester tester = new CodeTester();
                    IProgramCodeQuestionRepository repository = new ProgramCodeQuestionRepository(_context as ApplicationDbContext);
                    var question = repository.PickById(program.QuestionId);
                    var result = await tester.RunTestsAsync(question.GetTests, program.Program);
                    bool allRight = true;
                    foreach (var item in result.Values)
                    {
                        if (!item.Success) // answer is not correct
                        {
                            allRight = false;
                            break; // miss other tests
                        }
                    }
                    if (allRight) program.ApproveAnswer();
                    else program.RejectAnswer();
                    new QueuedProgramRepository(_context as ApplicationDbContext).Update(program);
                    _context.SaveChanges(); // then change to async
                }
            }
        }
    }
}
