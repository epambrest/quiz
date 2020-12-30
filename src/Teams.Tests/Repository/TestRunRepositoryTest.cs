using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Teams.Data;
using Teams.Data.TestRunRepos;
using Teams.Domain;

namespace Teams.Tests.Repository
{
    [TestFixture]
    public class TestRunRepositoryTest
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext _emptyContext;
        private ITestRunRepository _testRunRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestRunDataBase")
                .Options;
            _context = new ApplicationDbContext(options);
            _emptyContext = new ApplicationDbContext(options);
            _emptyContext.SaveChanges();
            var _mixedAnswersTestRun = new TestRun("john", Guid.NewGuid());
            var _textAnswersTestRun = new TestRun("jim", Guid.NewGuid());
            _mixedAnswersTestRun.AddAnswer(new Answer(Guid.NewGuid(), "1987"));
            _mixedAnswersTestRun.AddAnswer(new Answer(Guid.NewGuid(), new List<Guid>() {Guid.NewGuid()}));
            for (var i = 0; i < 3; i++) _textAnswersTestRun.AddAnswer(new Answer(Guid.NewGuid(), i.ToString()));
            _context.AddRange(_mixedAnswersTestRun);
            _context.AddRange(_textAnswersTestRun);
            _context.SaveChanges();
        }

        #region GetAllAsync

        [Test]
        public async Task GetAllAsync_TestRunRepository_ReturnsListCount10()
        {
            _testRunRepository = new TestRunRepository(_context);
            //Act
            var testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.AreEqual(_context.TestRuns.Count(), testRuns.Count);
        }
        #endregion

        #region GetByIdAsync

        [Test]
        public async Task GetByIdAsync_TestRunRepository_ReturnsTestRunId()
        {
            //Arrange
            _testRunRepository = new TestRunRepository(_context);
            var testRuns = await _testRunRepository.GetAllAsync();
            var id = testRuns.ElementAt(1).Id;
            //Act
            var currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.AreEqual(currentTestRun.Id, id);
        }
        
        [Test]
        public async Task GetByIdAsync_TestRunRepository_Returns_Legit_Answer_Entity()
        {
            //Arrange
            _testRunRepository = new TestRunRepository(_context);
            var testRuns = await _testRunRepository.GetAllAsync();
            var id = testRuns.ElementAt(0).Id;
            var currentTestRun = await _testRunRepository.GetByIdAsync(id);
            
            //Act
            var answer = currentTestRun.Answers.FirstOrDefault();
            //Assert
            Assert.AreEqual(answer.AnswerText, "1987");
            Assert.IsEmpty(answer.AnswerOptions);
        }

        [Test]
        public async Task GetByIdAsync_TestRunRepository_ReturnsNull()
        {
            //Arrange
            var id = new Guid("2d2c4834-3c9e-4d4d-ad2a-4c940940d78f");
            //Act
            var currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.IsNull(currentTestRun);
        }

        #endregion

        #region GetAllByUserAsync

        [Test]
        public async Task GetAllByUserAsync_TestRunRepository_ReturnsListCount16()
        {
            //Arrange
            const string userId = "jim";
            //Act
            var testRuns = await _testRunRepository.GetAllByUserAsync(userId);
            //Assert
            Assert.That(testRuns.Any(x => x.TestedUserId == userId));
        }

        [Test]
        public async Task GetAllByUserAsync_TestRunRepository_ReturnsEmptyList()
        {
            //Arrange
            _testRunRepository = new TestRunRepository(_context);
            //Act
            var testRuns = await _testRunRepository.GetAllByUserAsync("johnnie depp");
            //Assert
            Assert.AreEqual(testRuns.Count, 0);
        }

        #endregion

        private async Task SaveTestRunsToContext(TestRun testRun)
        {
            await _context.TestRuns.AddAsync(testRun);
            await _context.SaveChangesAsync();
        }
    }
}