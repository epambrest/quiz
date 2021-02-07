using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.ProgramTestRepos
{
    public interface IProgramTestRepository
    {
        Task<IList<ProgramTest>> GetProgramCodeTests(Guid id);
        Task Save(ProgramTest programTest);
        Task Update(ProgramTest programTest);
        Task Delete(int programTestId);
        Task<ProgramTest> GetByIdTest(int id);
    }
}
