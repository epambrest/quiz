using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.QuestionRepos;

namespace Teams.Controllers
{
    public class QuestionController: Controller
    {
        private IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository singleRepository)
        {
            _questionRepository = singleRepository;
        }
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var list =  await _questionRepository.GetQuestionsAsync();
            return Json(list);
        }
    }
}
