using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Teams.Domain
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("TestSets")]
        public ICollection<TestSet> TestSets { get; set; }
    }
}
