using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iTrasitionApp.Classes;
using iTrasitionApp.Models;
using iTrasitionApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace iTrasitionApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationContext context;
        public CompanyController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCompanyModel model)
        {
            if (model.UserId == null)
            {
                ClaimsPrincipal currentUser = this.User;
                model.UserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            using (var db = new DBLogic(context))
            {

                db.CreateCompany(model);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Company(int id = 1)
        {
            using (var db = new DBLogic(context))
            {
                return View(db.LoadCompanyByID(id));
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new DBLogic(context))
            {
                Company model = db.LoadCompanyByID(id);
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            using (var db = new DBLogic(context))
            {
                db.EditCompany(company);
                return RedirectToAction("Company","Company", new { id = company.Id });
            }
        }

        public IActionResult AddComment(Comment comm)
        {
            using (var db = new DBLogic(context))
            {
                if (comm.body != "")
                {
                    Comment comment = new Comment();
                    ClaimsPrincipal currentUser = this.User;
                    comment.UserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                    comment.CompanyId = comm.CompanyId;
                    comment.date = DateTime.Now;
                    comment.body = comm.body;
                    db.AddComment(comment);
                }
                return RedirectToAction("Company", "Company", new { id = comm.CompanyId });
            }

        }

        public IActionResult Like(int id)
        {
            using (DBLogic db = new DBLogic(context))
            {
                db.Like(id);
                return RedirectToAction("Index","Home");
            }
        }
    }
}
