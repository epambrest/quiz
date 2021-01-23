using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.ProgramTestRepos
{
    public class ProgramTestRepository : IProgramTestRepository
    {
        private readonly ApplicationDbContext _context;
        public ProgramTestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Delete(int programCodeTestId)
        {
            var progTest = _context.ProgramTests.FirstOrDefault(x => x.Id == programCodeTestId);
            if (progTest != null)
            {
                _context.ProgramTests.Remove(progTest);
                _context.SaveChanges();
            }
            return "Deleted";
        }

        public ProgramTest GetByIdTest(int id)
        {
            return _context.ProgramTests.FirstOrDefault(x => x.Id == id);
        }

        public List<ProgramTest> GetProgramCodeTests(Guid id)
        {
            return _context.ProgramTests.Where(x => x.QuestionId == id).ToList();
        }

        public void Save(ProgramTest programTest)
        {
            _context.ProgramTests.Add(programTest);
            _context.SaveChanges();
        }

        public void Update(ProgramTest programTest)
        {
            _context.ProgramTests.Update(programTest);
            _context.SaveChanges();
        }
    }
}
