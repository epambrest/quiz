using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.Repositories;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class TestRunController : Controller
    {
        private readonly IQuestionRepository _repository;
        private readonly IUserRepository _userRepository;

        public TestRunController(IQuestionRepository repo, IUserRepository userRepository)
        {
            this._repository = repo;
            this._userRepository = userRepository;
        }

        public IActionResult Question(Guid id)
        {

            var question = _repository.PickById(id);

            if (question == null) return NotFound();

            QuestionViewModel ivm = new QuestionViewModel()
            {
                Question = question
            };

            return View(ivm);
        }


        public IActionResult Answer(string answer, Guid questionId, string userId)
        {

            QuestionViewModel ivm = new QuestionViewModel()
            {
                TestRun = new TestRun(_repository.PickById(questionId), new Answers(answer), _userRepository.PickUserById(userId))
                {

                }
            };
            return View(ivm);
        }
    }
}
