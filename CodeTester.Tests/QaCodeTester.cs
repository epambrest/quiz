using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeTester.Tests
{   
    public class QaCodeTester
    {
        [Fact]
        public async Task RunTestsAsync_InsufficientTimeFrameForImplementation_RunningOutOfTime()
        {
            // Arrange
            var tester = new Tester();
            var outputString = "This text should not appear";
            var code = $@"using System;
                using System.Threading;
                namespace Testedcode
                {{
                    class Program
                    {{
                        static void Main(string[] args)
                        {{
                            Thread.Sleep(1000);
                            Console.WriteLine(""{outputString}"");
                        }}
                    }}
                }}";
            var test = new Test("", "", new TimeSpan(0, 0, 0, 0, 500));
           
            // Act
            var res = await tester.RunTestsAsync(new List<Test> { test }, code);
            
            // Assert
            Assert.False(res.Values.First().Output == outputString,"the code exited successfully when the timer was interrupted");
            Assert.True(res.Values.First().ExceededTheMaximumTime, "must be interrupted by timer");
        }
        [Fact]
        public async Task RunTestsAsync_SomeImputStrings_TheSameStringsInTheOutput()
        {
            // Arrange
            string code = @" using System;
                namespace Test
                {
                    public class Writer
                    {
                        static void Main(string[] args)
                        {                            
                              var str= Console.ReadLine();
                              Console.WriteLine(str);
                        }
                    }
                }";
            var tester = new Tester();
            var tests = new List<Test> { new Test("hello", "hello", new TimeSpan(0, 0, 0, 10, 0)),
                new Test("hellU", "hello", new TimeSpan(0, 0, 0, 10, 0)) };
            
            // Act
            var actual = await tester.RunTestsAsync(tests, code);
            
            // Assert
            Assert.Equal(new List<bool> { true, false }, actual.Select(t => t.Value.Success));
        }
        [Fact]
        public async Task RunTestsAsync_CodeWithException_TheSameExceptionInStdErr()
        {
            // Arrange
            string Errorcode = @"using System;
                    namespace testedcode
                    {
                        class Program
                        {
                            static void Main(string[] args)
                            {
                                throw new Exception(""Test exception"");
                            }
                        }
                    }";
            var tests = new List<Test> { new Test("", "", new TimeSpan(0, 0, 0, 10, 0)) };
            var tester = new Tester();
            
            // Act
            var res = await tester.RunTestsAsync(tests, Errorcode);
            var actual = res.First().Value;
            
            // Assert
            Assert.False(actual.Success);
            Assert.Contains("Test exception", actual.RuntimeErrors);
        }
        [Fact]
        public async Task RunTestsAsync_calculationOfFactorialInDifferentThreads_TheSameResultAsInMultithreading()
        {
            // Arrange
            var code = @"using System;
                        namespace testedcode
                        {
                            class Program
                            {
                                static void Main(string[] args)
                                {
                                    long result = 1;
                                    var x= int.Parse(Console.ReadLine());

                                    for (int i = 1; i <= x; i++)
                                    {
                                        result *= i;
                                    }
                                    Console.WriteLine(result);
                                }
                            }
                        }";
            var tests = new List<Test>();
            for (int i = 0; i < 30; i++)
            {
                var p = i % 20;
                tests.Add(new Test(p.ToString(), Factorial(p).ToString(), new TimeSpan(0, 0, 10)));
            }
            var codeTester = new Tester();
            
            // Act
            var res = await codeTester.RunTestsAsync(tests, code);
            var actual = res.Any(t => t.Value.Output != Factorial(int.Parse(t.Key.IncomingData))
            .ToString());
            
            // Assert
            Assert.False(actual, "different execution result in one or multiple threads");
        }
        private long Factorial(int x)
        {
            long result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}

