using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iTrasitionApp.Classes;
using iTrasitionApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace iTrasitionApp.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            CreateCompanyModel model = new CreateCompanyModel();
            model.UserId = currentUserID;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                DBLogic.CreateCompany(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Company(int id)
        {
            return View(DBLogic.LoadCompany(id));
        }
    }
}
