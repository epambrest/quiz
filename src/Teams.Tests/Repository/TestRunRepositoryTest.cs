using System;
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
        private ITestRunRepository _testRunRepository;
        private TestRun _mixedAnswersTestRun;
        private TestRun _textAnswersTestRun;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestRunDataBase")
                .Options;
            _context = new ApplicationDbContext(options);
            _mixedAnswersTestRun = new TestRun("john", Guid.NewGuid());
            _textAnswersTestRun = new TestRun("jim", Guid.NewGuid());
            _mixedAnswersTestRun.AddAnswer("1987", Guid.NewGuid());
            _mixedAnswersTestRun.AddAnswer(Guid.NewGuid(), Guid.NewGuid());
            for (var i = 0; i < 3; i++) _textAnswersTestRun.AddAnswer(i.ToString(), Guid.NewGuid());
        }

        #region GetAllAsync

        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsListCount10()
        {
            //Arrange
            await SaveTestRunsToContext(_mixedAnswersTestRun);
            await SaveTestRunsToContext(_textAnswersTestRun);
            //Act
            var testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.AreEqual(_context.TestRuns.Count(), testRuns.Count);
        }

        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsEmpty()
        {
            //Arrange
            _testRunRepository = new TestRunRepository(_context);
            //Act
            var testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.IsEmpty(testRuns);
        }

        #endregion

        #region GetByIdAsync

        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsTestRunId()
        {
            //Arrange
            var testRuns = await _testRunRepository.GetAllAsync();
            var id = testRuns.ElementAt(1).Id;
            //Act
            var currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.AreEqual(currentTestRun.Id, id);
        }

        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsNull()
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
        public async Task GetAllByUserAsync_TeamRepository_ReturnsListCount16()
        {
            //Arrange
            const string userId = "jim";
            //Act
            var testRuns = await _testRunRepository.GetAllByUserAsync(userId);
            //Assert
            Assert.That(testRuns.Any(x => x.TestedUserId == userId));
        }

        [Test]
        public async Task GetAllByUserAsync_TeamRepository_ReturnsEmptyList()
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