using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Data.Repositories
{
    public class TestRunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
