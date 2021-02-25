using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL;

namespace Lab.Quiz.DAL.Entities
{
    public class ProgramCodeQuestionViewModel
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
        public string Text { get; set; }
        public string AlertText { get; set; }
    }
}
