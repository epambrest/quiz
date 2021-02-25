using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab.Quiz.DAL.Entities
{
    public class QueuedProgram
    {
        public QueuedProgram(Guid questionId, string program, int status = 0)
        {
            QuestionId = questionId;
            Program = program;
            Status = status;
        }
        public long Id { get; private set; }
        public Guid QuestionId { get; private set; }
        public string Program { get; private set; }
        public int Status { get; private set; }
    }
}
