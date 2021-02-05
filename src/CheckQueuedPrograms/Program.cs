using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using Teams.Data;
using CodeTester;
using Teams.Data.Repositories;

namespace CheckQueuedPrograms
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
            // should we dispose context manually?
            var context = ApplicationDbContextFactory.GetContext();
            var questionRepository = ProgramCodeQuestionRepositoryFactory.GetRepository(context);
            var programsRepository = QueuedProgramRepositoryFactory.GetRepository(context);
            foreach (var program in context.QueuedPrograms)
            {
                if (program.Status == 0) // unchecked
                {
                    program.StartChecking();
                    Tester tester = new Tester();
                    var question = questionRepository.PickById(program.QuestionId);
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
                    programsRepository.Update(program);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
