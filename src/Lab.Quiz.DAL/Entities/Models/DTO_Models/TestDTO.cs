using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Entities
{
    public class TestDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public TestDTO()
        {
            Questions = new List<QuestionDTO>();
        }
    }
}
