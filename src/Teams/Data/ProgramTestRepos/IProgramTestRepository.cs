using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.ProgramTestRepos
{
    public interface IProgramTestRepository
    {
        List<ProgramTest> GetProgramCodeTests(Guid id);
        void Save(ProgramTest programTest);
        void Update(ProgramTest programTest);
        string Delete(int programTestId);
        ProgramTest GetByIdTest(int id);
    }
}
