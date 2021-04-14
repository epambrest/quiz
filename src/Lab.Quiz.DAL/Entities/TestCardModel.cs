using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Entities
{
    public class TestCardModel : Entity
    {
        public string Title { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
