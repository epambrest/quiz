using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Teams.Domain;

namespace Teams.Tests.Domain
{
    public class AnswerTests
    {
        private Guid _predefinedId;
        private Answer _defaultAnswerAsText;
        private Answer _defaultAnswerAsOptions;

        [SetUp]
        public void Setup()
        {
            _predefinedId = new Guid("f4340761-1211-48eb-9bea-b6052c28bac3");
            _defaultAnswerAsText = new Answer(Guid.NewGuid(), "answer");
            _defaultAnswerAsOptions = new Answer(Guid.NewGuid(), GenerateFakeAnswersIds(1));
        }

        #region Generate_Answer_Ids

        private List<Guid> GenerateFakeAnswersIds(int count)
        {
            var answers = new List<Guid> {_predefinedId};
            for (var i = 1; i < count; i++) answers.Add(Guid.NewGuid());
            return answers;
        }

        #endregion

        #region Verify_Immutable_Answer

        [Test]
        public void VerifyAnswerEntity_AnswerTextsAreImmutable()
        {
            //Arrange
            var changedAnswer = _defaultAnswerAsText.AnswerText;
            var oldAnswer = changedAnswer;
            //Act
            changedAnswer = "new answer";
            //Assert
            Assert.AreNotEqual(_defaultAnswerAsText.AnswerText, changedAnswer);
            Assert.AreEqual(_defaultAnswerAsText.AnswerText, oldAnswer);
        }

        [Test]
        public void VerifyAnswerEntity_AnswerOptionsAreImmutable()
        {
            //Arrange
            var newAnswerOption = _defaultAnswerAsOptions.AnswerOptions.ToList();
            // var oldAnswerOptions = newAnswerOption;
            //Act
            newAnswerOption.Add(Guid.NewGuid());
            //Assert
            Assert.AreNotEqual(_defaultAnswerAsOptions.AnswerOptions.Count, newAnswerOption.Count);
        }

        #endregion
    }
}