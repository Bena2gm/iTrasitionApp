using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTrasitionApp.Classes;
using iTrasitionApp.Models;
using iTrasitionApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace iTrasitionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;
        public HomeController(ApplicationContext context)
        {
            this.context = context;

        }
        public IActionResult Index(int page = 1)
        {
            using (var db = new DBLogic(context))
            {

                int pageSize = 5;   // количество элементов на странице

                IEnumerable<Company> source = db.LoadCompany();
                var count = source.Count();
                var items = source.Skip((page - 1) * pageSize).Take(pageSize);

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                CompanyViewModel viewModel = new CompanyViewModel
                {
                    PageViewModel = pageViewModel,
                    Company = items
                };


                return View(viewModel);
            }
        }
    }
}
