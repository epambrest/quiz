using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Teams.Data;
using Teams.Data.TestRunRepos;
using Teams.Domain;

namespace Teams.Tests.Domain
{
    public class TestRunTests
    {
        private List<TestRun> _testRunsWithOptions;
        private List<TestRun> _testRunsWithText;
        private List<TestRun> _mixedTestRuns;
        private Guid _defaultId;
        private string _firstUser;
        private string _secondUser;
        [SetUp]
        public void Setup()
        {
            _defaultId = new Guid("f4340761-1211-48eb-9bea-b6052c28bac3");
            _testRunsWithOptions = new List<TestRun>();
            _testRunsWithText = new List<TestRun>();
            _mixedTestRuns = new List<TestRun>();
            _firstUser = "johnie";
            _secondUser = "chris";
            _testRunsWithOptions.Add(GenerateMockTestRunWithOptions(_firstUser, _defaultId, 10));
            _testRunsWithText.Add(GenerateMockTestRun(_firstUser, 10));
            _mixedTestRuns.Add(GenerateMockTestRunWithOptions(_firstUser, _defaultId, 10));
            _mixedTestRuns.Add(GenerateMockTestRun(_firstUser, 10));
            
            for (int i = 0; i < 2; i++)
            {
                _testRunsWithOptions.Add(GenerateMockTestRunWithOptions(_secondUser, new Guid(), 10));
                _testRunsWithText.Add(GenerateMockTestRun(_secondUser, 10));
            }
        }

        #region Generate_Answers_And_TestRuns
        private List<Answer> GenerateMockAnswers(int count)
        {
            var answers = new List<Answer>();
            for (int i = 0; i < count; i++)
            {
                answers.Add(new Answer(i.ToString(),Guid.NewGuid(), 
                    Guid.NewGuid()));
            }
            return answers;
        }
        
        private List<Answer> GenerateMockAnswersAsOptions(int count, Guid id)
        {
            var answers = new List<Answer>();
            var guids = new List<Guid> {id};
            for (int i = 1; i < count; i++)
            {
                guids.Add(new Guid());
            }
            answers.Add(new Answer(guids, Guid.NewGuid(), Guid.NewGuid()));
            return answers;
        }
        
        private TestRun GenerateMockTestRun(string userId, int numberOfAnswers)
        {
            return new TestRun(userId, Guid.NewGuid(), 
                GenerateMockAnswers(numberOfAnswers));
        }
        
        private TestRun GenerateMockTestRunWithOptions(string userId, Guid id, int numberOfAnswers)
        {
            return new TestRun(userId, id, new List<Answer>
                (GenerateMockAnswersAsOptions( 9, id)));
        }
        #endregion

        #region AddsAnswer
        [Test]
        public void TestRun_Add_TextAnswer()
        {
            //Arrange
            var answers = GenerateMockAnswers(10);
            var testRun = _testRunsWithText.ElementAt(0);
            //Act
            testRun.Add(answers);
            //Assert
            Assert.AreEqual(testRun.Answers.Count, 20);
        }
        
        [Test]
        public void TestRun_Add_OptionsAnswer()
        {
            //Arrange
            var answers = GenerateMockAnswersAsOptions(10, new Guid());
            var singleAnswer = answers.FirstOrDefault();
            var testRun = _testRunsWithText.ElementAt(0);
            //Act
            testRun.Add(answers);
            // testRun.Add(singleAnswer);
            //Assert
            // Assert.AreEqual(testRun.Answers.Count, 21);
            Assert.AreEqual(answers.Count, 10);
        }
        #endregion
        
        #region ReturnsAnswer
        [Test]
        public void TestRun_Returns_TextAnswer()
        {
            //Arrange
            var answers = _testRunsWithText.FirstOrDefault().Answers;
            //Act
            var answerText = answers.ElementAt(0).AnswerText;
            var answerText2 = answers.ElementAt(1).AnswerText;
            var answerText9 = answers.ElementAt(9).AnswerText;
            //Assert
            Assert.AreEqual(answerText, "0");
            Assert.AreEqual(answerText2, "1");
            Assert.AreEqual(answerText9, "9");
        }
        
        [Test]
        public async Task TestRun_Returns_TextOptions()
        {
            //Arrange
            var answers = _testRunsWithOptions.FirstOrDefault().Answers;
            //Act
            var answerOption = Guid.Parse(answers.ElementAt(0).Answers.ElementAt(0));
            var answerOption2 = Guid.Parse(answers.ElementAt(0).Answers.ElementAt(1));
            var answerText = answers.ElementAt(0).AnswerText;
            //Assert
            Assert.AreEqual(answerOption, _defaultId);
            Assert.NotNull(answerOption2);
            Assert.Null(answerText);
        }
        
        [Test]
        public async Task TestRun_Returns_Mixed_Results()
        {
            //Arrange
            var answers = _testRunsWithOptions.FirstOrDefault().Answers;
            //Act
            var answerOption = Guid.Parse(answers.ElementAt(0).Answers.ElementAt(0));
            var answerOption2 = Guid.Parse(answers.ElementAt(0).Answers.ElementAt(1));
            var answerText = answers.ElementAt(0).AnswerText;
            //Assert
            Assert.AreEqual(answerOption, _defaultId);
            Assert.NotNull(answerOption2);
            Assert.Null(answerText);
        }
        #endregion
    }
}