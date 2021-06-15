using Lab.Quiz.BL.DependencyInjection;
using Lab.Quiz.BL.Services.OpenAnswerQuestionService;
using Lab.Quiz.Common.DependencyInjection;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;


namespace Lab.Quiz.BL.Tests.Services
{
    
    public class OpenAnswerQuestionTest
    {
        private  IMapper _mapper;
        private  IConfiguration configuration;

        public OpenAnswerQuestionTest()
        {
            var services = new ServiceCollection();
            services.AddCommonBootstrap(configuration);
            services.AddBusinessLayer(configuration);
            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        private OpenAnswerQuestion openAnswerQuestion = new OpenAnswerQuestion
        {
            Id = Guid.NewGuid(),
            Answer = "100%",
            Text = "How Much Of Our Brain Do We Use?"
        };

        [Fact]
        public async Task IsItem_NotNull_ShouldReturnTrue()
        { 
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.OpenAnswerQuestionsRepository.GetByIdAsync(openAnswerQuestion.Id)).ReturnsAsync(openAnswerQuestion);
            var openAnswerQuestionServiceMock = new OpenAnswerQuestionService(unitOfWorkMock.Object, _mapper);

            //Act 
            var result = await openAnswerQuestionServiceMock.Get(openAnswerQuestion.Id);


            //Assert
            Assert.NotNull(result);

        }
        
        [Theory]
        [InlineData(" 100% ", "100%", "100% ", " 100%")]
        public async Task IsCorrect_TestAnswers_ShouldReturnTrue(string testAnswer, string testAnswer2, string testAnswer3, string testAnswer4)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.OpenAnswerQuestionsRepository.GetByIdAsync(openAnswerQuestion.Id)).ReturnsAsync(openAnswerQuestion);
            var openAnswerQuestionServiceMock = new OpenAnswerQuestionService(unitOfWorkMock.Object, _mapper);

            //Act 
            var content = await openAnswerQuestionServiceMock.Get(openAnswerQuestion.Id);

            var result = openAnswerQuestionServiceMock.IsCorrectAnswer(testAnswer, content.Answer);
            var result2 = openAnswerQuestionServiceMock.IsCorrectAnswer(testAnswer2, content.Answer);
            var result3 = openAnswerQuestionServiceMock.IsCorrectAnswer(testAnswer3, content.Answer);
            var result4 = openAnswerQuestionServiceMock.IsCorrectAnswer(testAnswer4, content.Answer);

            //Assert
            Assert.True(result);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
        
        }

        [Fact]
        public async Task IsAnswer_Correct_ShouldReturnTrue()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.OpenAnswerQuestionsRepository.GetByIdAsync(openAnswerQuestion.Id)).ReturnsAsync(openAnswerQuestion);
            var openAnswerQuestionServiceMock = new OpenAnswerQuestionService(unitOfWorkMock.Object, _mapper);

            //Act 
            var content = await openAnswerQuestionServiceMock.Get(openAnswerQuestion.Id);

            //Assert
            Assert.Equal(content.Answer, "100%");        
        }

        [Fact]
        public async Task IsQuestion_Correct_ShouldReturnTrue()
        {

            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.OpenAnswerQuestionsRepository.GetByIdAsync(openAnswerQuestion.Id)).ReturnsAsync(openAnswerQuestion);
            var openAnswerQuestionServiceMock = new OpenAnswerQuestionService(unitOfWorkMock.Object, _mapper);

            //Act 
            var content = await openAnswerQuestionServiceMock.Get(openAnswerQuestion.Id);

            //Assert
            Assert.Equal(content.Question, "How Much Of Our Brain Do We Use?");
            
        }
    }
}
