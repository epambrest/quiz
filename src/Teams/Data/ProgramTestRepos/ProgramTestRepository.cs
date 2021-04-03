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
        public async Task Delete(int programCodeTestId)
        {
            var progTest = await _context.ProgramTests.FirstOrDefaultAsync(x => x.Id == programCodeTestId);
            if (progTest != null)
            {
                _context.ProgramTests.Remove(progTest);
                 await _context.SaveChangesAsync();
            }
        }

        public async Task<ProgramTest> GetByIdTest(int id)
        {
            return await _context.ProgramTests.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<ProgramTest>> GetProgramCodeTests(Guid id)
        {
            return await _context.ProgramTests.Where(x => x.QuestionId == id).ToListAsync();
        }

        public async Task Add(ProgramTest programTest)
        {
            await _context.ProgramTests.AddAsync(programTest);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProgramTest programTest)
        {
            _context.ProgramTests.Update(programTest);
            await _context.SaveChangesAsync();
        }
    }
}
