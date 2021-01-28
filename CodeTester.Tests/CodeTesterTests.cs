
using CodeTester;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Xunit;

namespace CodeTesterTests
{
    public class Tests
    {
        [Fact]
        public async void ÑompileUsingStandartReferencesAsync_Sum3And2Code_5()
        {
            string code = @"
                using System;

                namespace Test
                {
                    public class Test
                    {
                        public static void Main(string[] args)
                        {                           
                        }
                   
                        public int Calc(int firstOperand )
                        {
                            return firstOperand+2;
                        }
                    }
                }";

            var firstOperand = 3;
            var expectedAdditionResult = 5;
            var compiler = new Compiler();
            using (var compileResult = await compiler.ÑompileUsingStandartReferencesAsync(code))
            {
                var type = Assembly.Load(File.ReadAllBytes(compileResult.Path)).GetType("Test.Test");
                var compileInstace = Activator.CreateInstance(type);
                var actual = type.GetMethod("Calc").Invoke(compileInstace, new[] { (object)firstOperand });
                Assert.Equal(expectedAdditionResult, actual);
            }
        }

        [Fact]
        public async void RunTestsAsync_InsufficientTimeFrameForImplementation_RunningOutOfTime
()
        {
            var tester = new Tester();
            var code = @"using System;
                using System.Threading;

                namespace Testedcode
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            Thread.Sleep(50);
                        }
                    }
                }";
            var test = new Test("", "", new TimeSpan(0, 0, 0, 0, 25));
            var res = await tester.RunTestsAsync(new List<Test> { test }, code);
            Assert.True(res.Values.First().ExceededTheMaximumTime, "the code must be timed out ");
        }
        [Fact]
        public async void RunTestsAsync_SomeImputStrings_TheSameStringsInTheOutput()
        {
            string code = @"
                using System;

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
            var tests = new List<Test> { new Test("hello", "hello", new TimeSpan(0, 0, 0, 10, 0)),
                new Test("hellU", "hello", new TimeSpan(0, 0, 0, 10, 0)) };

            var tester = new Tester();
            var actual = await tester.RunTestsAsync(tests, code);
            Assert.Equal(new List<bool> { true, false }, actual.Select(t => t.Value.Success));
        }

        [Fact]
        public async void RunTestsAsync_CodeWithException_TheSameExceptionInStdErr()
        {
            string Errorcode = @"
                                   using System;

                    namespace testedcode
                    {
                        class Program
                        {
                            static void Main(string[] args)
                            {
                                throw new Exception(""Test exception"");
                            }
                        }
                    }
                    ";
            var tests = new List<Test> { new Test("", "", new TimeSpan(0, 0, 0, 10, 0)) };
            var tester = new Tester();
            var res = await tester.RunTestsAsync(tests, Errorcode);
            var actual = res.First().Value;
            Assert.False(actual.Success);
            Assert.Contains("Test exception", actual.RuntimeErrors);
        }



        [Fact]
        public async void RunTestsAsync_calculationOfFactorialInDifferentThreads_TheSameResults
()
        {
            var code = @"using System;
                        using System.Threading;

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
            var res = await codeTester.RunTestsAsync(tests, code);
            var actual = res.Any(t => t.Value.Output != Factorial(int.Parse(t.Key.IncomingData))
            .ToString() + Environment.NewLine);
            Assert.True(actual, "different execution result in one or multiple threads");
        }


        private int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }


    }
}
