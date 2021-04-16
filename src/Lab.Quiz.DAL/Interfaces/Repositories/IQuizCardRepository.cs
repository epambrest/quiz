using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IQuizCardRepository 
    {
        public List<QuizCardDALModel> GetAll();
        public QuizCardDALModel Get(Guid id);
    }
}
