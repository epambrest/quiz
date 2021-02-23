using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace CodeTester.Tests
{
   public class QaCompiler
    {
        [Fact]
        public async Task CompileUsingStandartReferencesAsync_Sum3And2Code_5()
        {
            // Arrange
            string code = @"using System;
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
            
            // Act
            using var compileResult = await compiler.CompileUsingStandartReferencesAsync(code);
            var type = Assembly.Load(File.ReadAllBytes(compileResult.Path))
                .GetType("Test.Test");
            var compileInstace = Activator.CreateInstance(type);
            var actual = type.GetMethod("Calc")
                .Invoke(compileInstace, new[] { (object)firstOperand });
            
            // Assert
            Assert.Equal(expectedAdditionResult, actual);
        }
    }
}

