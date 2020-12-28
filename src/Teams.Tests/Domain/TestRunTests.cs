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

        #region Generate_Answers

        private List<Guid> GenerateMockAnswersIds(int count)
        {
            var answers = new List<Guid> {_predefinedId};
            for (var i = 1; i < count; i++) answers.Add(Guid.NewGuid());
            return answers;
        }

        #endregion

        #region AddsAnswer

        [Test]
        public void TestRun_Add_AnswerIds_ReturnsAsExpected()
        {
            //Arrange
            var answers = GenerateMockAnswersIds(3);
            var testRun = new TestRun(_user, Guid.NewGuid());
            var testQuestionFakeId = new Guid();
            //Act
            testRun.AddAnswer(answers, testQuestionFakeId);
            //Assert
            Assert.AreEqual(testRun.AnswersIds.Count, 3);
        }

        #endregion

        #region ReturnsAnswer

        [Test]
        public void TestRun_Returns_AnswerIds()
        {
            //Arrange
            var testRun = new TestRun(_user, Guid.NewGuid());
            var answers = testRun.AnswersIds;
            //Act
            var answerText = answers.ElementAt(0);
            var answerText2 = answers.ElementAt(1);
            var answerText9 = answers.ElementAt(9);
            //Assert
            Assert.AreEqual(answerText, _predefinedId);
            Assert.NotNull(answerText2);
            Assert.NotNull(answerText9);
            Assert.Throws<ArgumentOutOfRangeException>(() => answerText = answers.ElementAt(100));
        }

        #endregion
    }
}