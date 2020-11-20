using Microsoft.AspNetCore.Http;
using System;

namespace Teams.Models
{
    public class ProgramCodeQuestionViewModel
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
        public string Text { get; set; }
        public string AlertText { get; set; }
    }
}
