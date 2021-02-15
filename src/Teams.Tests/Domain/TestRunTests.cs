using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Teams.Domain;

namespace Teams.Tests.Domain
{
    public class TestRunTests
    {
        private Guid _predefinedId;
        private string _user;

        [SetUp]
        public void Setup()
        {
            _predefinedId = new Guid("f4340761-1211-48eb-9bea-b6052c28bac3");
            _user = "johnie";
        }

        private List<Guid> GenerateMockAnswersIds(int count)
        {
            var answersIds = new List<Guid> {_predefinedId};
            for (var i = 1; i < count; i++) answersIds.Add(Guid.NewGuid());
            return answersIds;
        }

        [Test]
        public void TestRun_Add_AnswerOptions_ReturnsAsExpected()
        {
            //Arrange
            var answersIds = GenerateMockAnswersIds(3);
            var testRun = new TestRun(_user, Guid.NewGuid());
            var testQuestionFakeId = new Guid();
            //Act
            testRun.AddAnswer(new Answer(testQuestionFakeId, answersIds));
            testRun.AddAnswer(new Answer(testQuestionFakeId, answersIds));
            //Assert
            Assert.AreEqual(testRun.Answers.Count, 2);
            Assert.IsNull(testRun.Answers.ElementAt(0).AnswerText);
        }
        
        public void TestRun_Add_AnswerText_ReturnsAsExpected()
        {
            //Arrange
            var answersIds = GenerateMockAnswersIds(3);
            var testRun = new TestRun(_user, Guid.NewGuid());
            var testQuestionFakeId = new Guid();
            //Act
            testRun.AddAnswer(new Answer(testQuestionFakeId, "johnie"));
            testRun.AddAnswer(new Answer(testQuestionFakeId, "mnemonic"));
            //Assert
            Assert.AreEqual(testRun.Answers.Count, 2);
            Assert.IsNull(testRun.Answers.ElementAt(0).AnswerText);
        }

        [Test]
        public void TestRun_Returns_Actual_Answer_As_Option_Text_As_Null()
        {
            //Arrange
            var testRun = new TestRun(_user, Guid.NewGuid());
            var sampleAnswer = new Answer(Guid.NewGuid(), new List<Guid>() {_predefinedId});
            testRun.AddAnswer(sampleAnswer);
            //Act
            var answers = testRun.Answers;
            var actualAnswerOptions = answers.ElementAt(0).AnswerOptions;
            var actualAnswerText = answers.ElementAt(0).AnswerText;
            //Assert
            Assert.IsNotNull(actualAnswerOptions);
            Assert.AreEqual(actualAnswerOptions.ElementAt(0), _predefinedId);
            Assert.IsNull(actualAnswerText);
        }
        
        [Test]
        public void TestRun_Returns_Actual_Answer_As_Text_Options_As_Null()
        {
            //Arrange
            var testRun = new TestRun(_user, Guid.NewGuid());
            var sampleAnswer = new Answer(Guid.NewGuid(), "answer");
            testRun.AddAnswer(sampleAnswer);
            //Act
            var answers = testRun.Answers;
            var actualAnswerOptions = answers.ElementAt(0).AnswerOptions;
            var actualAnswerText = answers.ElementAt(0).AnswerText;
            //Assert
            Assert.IsNotNull(actualAnswerText);
            Assert.AreEqual(actualAnswerText, "answer");
            Assert.IsEmpty(actualAnswerOptions);
        }

        [Test]
        public void TestRun_Answers_Is_Immutable()
        {
            //Arrange
            var testRun = new TestRun(_user, Guid.NewGuid());
            var sampleAnswer = new Answer(Guid.NewGuid(), new List<Guid>() {_predefinedId});
            testRun.AddAnswer(sampleAnswer);

            //Act
            var answers = testRun.Answers.ToList();
            answers.Add(new Answer(Guid.NewGuid(), "answer"));
            //Assert
            Assert.AreNotEqual(answers, testRun.Answers);
            Assert.AreNotEqual(answers.Count, testRun.Answers.Count);
        }
    }
}