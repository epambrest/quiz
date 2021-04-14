using System.Collections.Generic;
using System.Threading.Tasks;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab.Quiz.BL.Services.TestCardService
{
    internal class TestCardService : ITestCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestCardService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<TestCardVModel>> GetAllTestCards()
        {
            var tests = await _unitOfWork.TestsRepository.GetAll()
                .Include(x => x.TestQuestions)
                .ToListAsync();

            return _mapper.Map<ICollection<TestCardModel>, ICollection<TestCardVModel>>(tests);
        }

        public async Task CreateTestCard(string testCardName)
        {
         var testCardVModel =  _mapper.Map<TestCardVModel, TestCardModel>(new TestCardVModel {TestTitle = testCardName });
         _unitOfWork.TestsRepository.Add(testCardVModel);
         await _unitOfWork.SaveAsync();
        }
    }
}
