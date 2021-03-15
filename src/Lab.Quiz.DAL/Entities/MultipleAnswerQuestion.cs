using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Net.Mime;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Quiz.DAL.Entities
{
    public class MultipleAnswerQuestion : Question
    {
        public ICollection<MultipleAnswerQuestionOption> Answers { get; set; }
    }
}
