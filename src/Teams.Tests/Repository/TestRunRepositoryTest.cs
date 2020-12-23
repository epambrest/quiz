using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Teams.Data;
using Teams.Data.TestRunRepos;
using Moq;
using Teams.Domain;
using Teams.Models;

namespace Teams.Tests.Repository
{
    [TestFixture]
    public class TestRunRepositoryTest
    {
        private ApplicationDbContext _context;
        private ITestRunRepository _testRunRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestRunDataBase")
                .Options;
            _context = new ApplicationDbContext(options);
        }
        
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
        
        private TestRun GenerateMockTestRun(string userId, int numberOfAnswers)
        {
            return new TestRun(userId, Guid.NewGuid(), 
                GenerateMockAnswers(numberOfAnswers));
        }
        
        #region GetAllAsync
        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsListCount10()
        {
            //Arrange
            var testRuns = new List<TestRun>();
            for (int i = 0; i < 10; i++)
            {
                testRuns.Add(GenerateMockTestRun("johnie_silverhand", 10));
            }
            await SaveTestRunsToContext(testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.AreEqual(_context.TestRuns.Count(), testRuns.Count);
        }
        #endregion
        
        [Test]
        public async Task GetAllAsync_TeamRepository_ReturnsEmpty()
        {
            //Arrange
            var testRuns = new List<TestRun>();
            // for (int i = 0; i < 10; i++)
            // {
            //     testRuns.Add(GenerateMockTestRun("johnie_silverhand", 10));
            // }
            await SaveTestRunsToContext(testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            testRuns = await _testRunRepository.GetAllAsync();
            //Assert
            Assert.IsEmpty(testRuns);
        }
        
        #region GetByIdAsync
        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsTestRunId()
        {
            //Arrange
            var testRuns = new List<TestRun>();
            for (int i = 0; i < 10; i++)
            {
                testRuns.Add(GenerateMockTestRun("johnie_silverhand", 10));
            }
            Guid id = new Guid("2d2c4834-3c9e-4d4d-ad2a-4c940940d68f");
            testRuns.ElementAt(0).Id = id;
            await SaveTestRunsToContext(testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            TestRun currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.AreEqual(currentTestRun.Id, id);
        }
        
        [Test]
        public async Task GetByIdAsync_TeamRepository_ReturnsNull()
        {
            //Arrange
            var testRuns = new List<TestRun>();
            for (int i = 0; i < 10; i++)
            {
                testRuns.Add(GenerateMockTestRun("johnie_silverhand", 10));
            }
            Guid id = new Guid("2d2c4834-3c9e-4d4d-ad2a-4c940940d78f");
            await SaveTestRunsToContext(testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            TestRun currentTestRun = await _testRunRepository.GetByIdAsync(id);
            //Assert
            Assert.IsNull(currentTestRun);
        }
        #endregion
        
        #region GetAllByUserAsync
        [Test]
        public async Task GetAllByUserAsync_TeamRepository_ReturnsListCount10()
        {
            //Arrange
            var testRuns = new List<TestRun>();
            for (int i = 0; i < 3; i++)
            {
                testRuns.Add(GenerateMockTestRun("danny boyle", 10));
            }
            
            for (int i = 0; i < 3; i++)
            {
                testRuns.Add(GenerateMockTestRun("cr7", 10));
            }
            
            await SaveTestRunsToContext(testRuns);
            _testRunRepository = new TestRunRepository(_context);
            //Act
            testRuns = await _testRunRepository.GetAllByUserAsync("johnie_silverhand");
            //Assert
            Assert.AreEqual(testRuns.Count, 10);
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