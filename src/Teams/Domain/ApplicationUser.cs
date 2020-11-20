using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Teams.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public double SuccessRate { get; set; }
        [ForeignKey("Tests Completed")]
        public ICollection<TestSample> TestsCompleted { get; set; }

        public void CalcStats()
        {
            SuccessRate = (double) TestsCompleted.Count(c => c.IsCorrect) / TestsCompleted.Count;
        }
    }
}
