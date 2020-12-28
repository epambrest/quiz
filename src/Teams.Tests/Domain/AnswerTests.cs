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
            _defaultAnswerAsText = new Answer(Guid.NewGuid(), Guid.NewGuid());
            _defaultAnswerAsText.Add("answer");
            _defaultAnswerAsOptions = new Answer(Guid.NewGuid(), Guid.NewGuid());
            _defaultAnswerAsOptions.Add(GenerateFakeAnswersIds(1));
        }

        #region Generate_Answer_Ids

        private List<Guid> GenerateFakeAnswersIds(int count)
        {
            var answers = new List<Guid> {_predefinedId};
            for (var i = 1; i < count; i++) answers.Add(Guid.NewGuid());
            return answers;
        }

        #endregion

        #region AddText

        [Test]
        public void Answer_Add_AnswerAsText_Returns_String()
        {
            //Arrange
            var answer = _defaultAnswerAsText;
            const string newAnswer = "new answer";
            //Act
            answer.Add(newAnswer);
            //Assert
            Assert.AreEqual(answer.AnswerText, newAnswer);
            Assert.IsEmpty(answer.AnswerOptions);
        }

        [Test]
        public void Answer_Add_AnswerAsOptions_Returns_Guids()
        {
            //Arrange
            var answer = _defaultAnswerAsOptions;
            var newGuids = GenerateFakeAnswersIds(4);
            //Act
            answer.Add(newGuids);
            answer.Add(_predefinedId);
            //Assert
            Assert.AreEqual(answer.AnswerOptions.Count, 6);
            Assert.AreEqual(answer.AnswerOptions.ElementAt(5), _predefinedId);
        }

        [Test]
        public void Answer_Attempt_AddAnswerAsText_AnswerContainsOptions()
        {
            //Arrange
            var answer = _defaultAnswerAsOptions;
            //Act
            answer.Add("text");
            //Assert
            Assert.IsEmpty(answer.AnswerText);
        }

        [Test]
        public void Answer_Attempt_AddAnswerAsOptions_AnswerContainsText()
        {
            //Arrange
            var answer = _defaultAnswerAsText;
            //Act
            answer.Add(Guid.NewGuid());
            //Assert
            Assert.IsEmpty(answer.AnswerOptions);
        }

        #endregion

        #region Verify_Immutable_Answer

        [Test]
        public void VerifyAnswerEntity_AnswerTextsAreImmutable()
        {
            //Arrange
            var newAnswer = _defaultAnswerAsText.AnswerText;
            var oldAnswer = newAnswer;
            //Act
            newAnswer = "new answer";
            //Assert
            Assert.AreNotEqual(oldAnswer, newAnswer);
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