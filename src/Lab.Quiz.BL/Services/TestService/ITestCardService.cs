using Lab.Quiz.BL.Services.TestService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.Quiz.BL.Services.TestService
{

    public interface ITestCardService
    {
        Task<ICollection<TestCardModel>> GetTests();
    }
}
