using Lab.Quiz.BL.Services.TestCardService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.Quiz.BL.Services.HomeService
{
    public interface IFilterable
    {
        ICollection<TestQuestionModel> FilterQuestions(string testId, string questionType);
    }
}
