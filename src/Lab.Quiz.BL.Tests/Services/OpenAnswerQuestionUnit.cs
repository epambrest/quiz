using Lab.Quiz.BL.Services.OpenAnswerQuestionService;
using Lab.Quiz.BL.Services.OpenAnswerQuestionService.Mapping;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Lab.Quiz.BL.Tests.Services
{

    public class OpenAnswerQuestionUnit
    {
        private static  readonly DbContextOptions<ApplicationDbContext> _opts;
        private static  readonly IMapper _mapper;
        
       static OpenAnswerQuestionUnit()
       {


            _opts = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(databaseName: "LastTryToChangeDatabase")
                  .Options;

            using (var context = new ApplicationDbContext(_opts))
            {
                if (_mapper == null)
                {
                    context.OpenAnswerQuestions.AddRange(TestOpenAnswerQuestions);
                    context.SaveChanges();
                }
            }


            var services = new ServiceCollection();
            services.AddScoped<IManualMapperProfile, OpenAnswerMapperProfile>();
            services.AddScoped<IMapper, ManualModelMapper>();
            services.AddScoped<ICollection<IManualMapperProfile>>(sp => sp.GetServices<IManualMapperProfile>().ToList());
            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();


       }

        protected static List<OpenAnswerQuestion> TestOpenAnswerQuestions => new List<OpenAnswerQuestion>
        {
            new OpenAnswerQuestion{ Id = new Guid("59d7bfde-28eb-49bb-ba9d-1e8111dae34a"), Answer ="100%", Text = "How Much Of Our Brain Do We Use?"  },
            new OpenAnswerQuestion{ Id = new Guid("bb028d04-8fb3-4d2e-8d04-0a8c62681312"), Answer ="twenty", Text = "HOw old a u?"  },
            new OpenAnswerQuestion{ Id = new Guid("0e9845ea-9123-4261-9119-22fb7eaa1688"), Answer ="four", Text = "If you have a bowl with six apples and you take away four, how many do you have?"}
        };

        [Theory]
        [InlineData(" 100%", "100% ", " 100% ", "100%")]
        public async Task IsAnswer_Valid_ShouldReturnTrue(string testAnswer, string testAnswer2, string testAnswer3, string testAnswer4)
        {
            using (var context = new ApplicationDbContext(_opts))
            {
                //Arrange
                Guid guid1 =  new Guid("59d7bfde-28eb-49bb-ba9d-1e8111dae34a");
                IUnitOfWork uowRepos = new UnitOfWork(context);
                IOpenAnswerQuestionService service = new OpenAnswerQuestionService(uowRepos, _mapper);
                var content = await service.Get(guid1);

                //Act
                var result = service.IsCorrectAnswer(testAnswer, content.Answer);
                var result2 = service.IsCorrectAnswer(testAnswer2, content.Answer);
                var result3 = service.IsCorrectAnswer(testAnswer3, content.Answer);
                var result4 = service.IsCorrectAnswer(testAnswer4, content.Answer);


                //Assert
                Assert.True(result);
                Assert.True(result2);
                Assert.True(result3);
                Assert.True(result4);
            }

        }

        [Fact]
        public async Task IsGuid_ValidGuid_ShouldReturnTrue()
        {
            using (var context = new ApplicationDbContext(_opts))
            {
                //Arrange
                Guid guid2 = new Guid("59d7bfde-28eb-49bb-ba9d-1e8111dae34a");
                IUnitOfWork uowRepos = new UnitOfWork(context);
                IOpenAnswerQuestionService service = new OpenAnswerQuestionService(uowRepos, _mapper);

                //Act
                var res = await service.Get(guid2);

                //Assert
                Assert.NotNull(res);

            }
        }

        [Fact]
        public async Task IsGuid_NotValidGuid_ShouldReturnFalse()
        {
            using (var context = new ApplicationDbContext(_opts))
            {
                //Arrange
                Guid guid3 = new Guid("bb028d04-8fb3-4d2e-8d04-0a8c62681312");
                IUnitOfWork uowRepos = new UnitOfWork(context);
                IOpenAnswerQuestionService service = new OpenAnswerQuestionService(uowRepos, _mapper);

                //Act
                var res = await service.Get(guid3);

                //Assert
                Assert.NotNull(res);

            }
        }

        [Fact]
        public async Task IsAnswer_Correct_ShouldReturnTrue()
        {
            using (var context = new ApplicationDbContext(_opts))
            {
                //Arrange
                Guid guid4 = new Guid("0e9845ea-9123-4261-9119-22fb7eaa1688");
                IUnitOfWork uowRepos = new UnitOfWork(context);
                IOpenAnswerQuestionService service = new OpenAnswerQuestionService(uowRepos, _mapper);

                //Act
                var res = await service.Get(guid4);

                //Assert
                Assert.Equal(res.Answer, "four");

            }
        }

        [Fact]
        public async Task IsQuestion_Correct_ShouldReturnTrue()
        {
            using (var context = new ApplicationDbContext(_opts))
            {
                //Arrange
                Guid guid5 = new Guid("0e9845ea-9123-4261-9119-22fb7eaa1688");
                IUnitOfWork uowRepos = new UnitOfWork(context);
                IOpenAnswerQuestionService service = new OpenAnswerQuestionService(uowRepos, _mapper);

                //Act
                var res = await service.Get(guid5);

                //Assert
                Assert.Equal(res.Question, "If you have a bowl with six apples and you take away four, how many do you have?");

            }

        }
    }
}
