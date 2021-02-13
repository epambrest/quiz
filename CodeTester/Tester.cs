using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static CodeTester.Compiler;

namespace CodeTester
{
    public class Tester
    {
        public TimeSpan DefaultMaximumExecutionTime { get; set; } = new TimeSpan(0, 1, 0);
        private Compiler Compiler = new Compiler();
        private CompileResult compileResult;
        public async Task<Dictionary<Test, TestResult>> RunTestsAsync(IEnumerable<Test> tests, string code)
        {
            CheckIfTestsAreCorrect(tests);
            using (compileResult = await Compiler.CompileUsingStandartReferencesAsync(code))
            {
                if (compileResult.Success)
                {
                    return await Task.Run(() => tests.AsParallel()
                            .Select(test => new { testResult = StartWithTimeLimit(test), test = test })
                            .ToDictionary(test => test.test, result => result.testResult));
                }
                var failCompilResult = new TestResult(false, null, new TimeSpan(), false,
                   compileResult.Diagnostics, null);
                return tests.ToDictionary(test => test, result => failCompilResult);
            }
        }
        private void CheckIfTestsAreCorrect(IEnumerable<Test> tests)
        {
            if (tests == null)
            {
                throw new ArgumentNullException("collection shouldn't be null");
            }

            if (tests.GroupBy(t => t).Where(t => t.Count() > 1).Any())
            {
                throw new ArgumentException("identical tests are not allowed");
            }

        }
        private TestResult StartWithTimeLimit(Test test)
        {
            using (var process = GetInitedProcess())
            {
                if (process.Start())
                {
                    bool exceededTheMaximumTime = false;
                    bool hasExited = false;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var token = GetInitedToken(test);
                    token.Register(() => { if (!hasExited) { process.Kill(); exceededTheMaximumTime = true; } });
                    process.StandardInput.Write(GetIncomingString(test));
                    process.WaitForExit();
                    hasExited = true;
                    var outputError = process.StandardError.ReadToEnd().Trim();
                    var output = process.StandardOutput.ReadToEnd().Trim();
                    bool success = CheckIfTheOutputIsCorrect(test, output)
                        && string.IsNullOrEmpty(outputError) && !exceededTheMaximumTime;
                    return new TestResult(success, output,
                    stopwatch.Elapsed, exceededTheMaximumTime, compileResult.Diagnostics, outputError);
                }
                else throw new InvalidOperationException("process startup error");
            }
        }
        private CancellationToken GetInitedToken(Test test)
        {
            var maximumExecutionTime = DefaultMaximumExecutionTime;
            if (test.MaximumExecutionTime < maximumExecutionTime)
            {
                maximumExecutionTime = test.MaximumExecutionTime;
            }
            return new CancellationTokenSource(maximumExecutionTime).Token;
        }
        private string GetIncomingString(Test test)
        {
            if (!test.IncomingData.EndsWith(Environment.NewLine))
            {
                return test.IncomingData + Environment.NewLine;
            }
            return test.IncomingData;
        }
        private bool CheckIfTheOutputIsCorrect(Test test, string output)
        {
            return output == test.ExpectedOutgoingData;
        }
        private Process GetInitedProcess()
        {
            var process = new Process();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = compileResult.Path;
            return process;
        }
    }
}