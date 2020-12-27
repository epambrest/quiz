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
        private ITestRunRepository _testRunRepository;
        private List<TestRun> _testRuns;
        private List<Answer> _mixedAnswers;
        private List<Answer> _answersAsText;
        private List<Answer> _answersAsOptions;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestRunDataBase")
                .Options;
            _context = new ApplicationDbContext(options);
            _testRuns = new List<TestRun>();
            _mixedAnswers = new List<Answer>();
            _answersAsText = new List<Answer>();
            _answersAsOptions = new List<Answer>();

            _mixedAnswers.Add(new Answer("1987", Guid.NewGuid(), Guid.NewGuid()));
            _mixedAnswers.Add(new Answer(new List<Guid> {Guid.NewGuid()}, Guid.NewGuid(), Guid.NewGuid()));
            for (var i = 0; i < 3; i++)
            {
                _answersAsText.Add(new Answer(i.ToString(), Guid.NewGuid(), Guid.NewGuid()));
                _answersAsOptions.Add(new Answer(new List<Guid> {Guid.NewGuid()}, Guid.NewGuid(), Guid.NewGuid()));
            }

            _context.Answers.AddRange(_mixedAnswers);
            _context.Answers.AddRange(_answersAsText);
            _context.Answers.AddRange(_answersAsOptions);
            _context.TestRuns.AddRange(_testRuns);
            _context.SaveChanges();
        }

        #region GetAllAsync

        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsListCount10()
        {
            //Arrange
            _testRuns = new List<TestRun>();
            for (var i = 0; i < 10; i++)
                _testRuns.Add(new TestRun("johnie_silverhand", Guid.NewGuid(),
                    _answersAsText.Select(x => x.Id).ToList()));
            await SaveTestRunsToContext(_testRuns);

            _testRunRepository = new TestRunRepository(_context);
            //Act
            _testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.AreEqual(_context.TestRuns.Count(), _testRuns.Count);
        }

        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsEmpty()
        {
            //Arrange
            _testRuns = new List<TestRun>();
            await SaveTestRunsToContext(_testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            _testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.IsEmpty(_testRuns);
        }

        #endregion

        #region GetByIdAsync

        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsTestRunId()
        {
            //Arrange
            _testRuns = new List<TestRun>();
            for (var i = 0; i < 10; i++)
                _testRuns.Add(new TestRun("johnie_silverhand", Guid.NewGuid(),
                    _answersAsText.Select(x => x.Id).ToList()));
            var id = new Guid("2d2c4834-3c9e-4d4d-ad2a-4c940940d68f");
            _testRuns.ElementAt(0).Id = id;
            await SaveTestRunsToContext(_testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            var currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.AreEqual(currentTestRun.Id, id);
        }

        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsNull()
        {
            //Arrange
            _testRuns = new List<TestRun>();
            for (var i = 0; i < 10; i++)
                _testRuns.Add(new TestRun("johnie_silverhand", Guid.NewGuid(),
                    _answersAsText.Select(x => x.Id).ToList()));
            var id = new Guid("2d2c4834-3c9e-4d4d-ad2a-4c940940d78f");
            await SaveTestRunsToContext(_testRuns);
            _testRunRepository = new TestRunRepository(_context);
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
            _testRuns = new List<TestRun>();
            for (var i = 0; i < 10; i++)
                _testRuns.Add(new TestRun("james", Guid.NewGuid(), _answersAsText.Select(x => x.Id).ToList()));
            await SaveTestRunsToContext(_testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            _testRuns = await _testRunRepository.GetAllByUserAsync("james");
            //Assert
            Assert.AreEqual(_testRuns.Count, 10);
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

        private async Task SaveTestRunsToContext(List<TestRun> testRuns)
        {
            await _context.TestRuns.AddRangeAsync(testRuns);
            await _context.SaveChangesAsync();
        }
    }
}