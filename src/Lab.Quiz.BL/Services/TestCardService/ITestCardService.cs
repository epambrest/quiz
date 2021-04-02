using System.Collections.Generic;
using System.Threading.Tasks;
using Lab.Quiz.BL.Services.TestCardService.Models;

namespace Lab.Quiz.BL.Services.TestCardService
{

    public interface ITestCardService
    {
        Task<ICollection<TestCardModel>> GetTests();
    }
}
