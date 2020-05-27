using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTrasitionApp.Classes;
using Microsoft.AspNetCore.Mvc;

namespace iTrasitionApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            return View(DBLogic.LoadCompany(id));
        }
    }
}
