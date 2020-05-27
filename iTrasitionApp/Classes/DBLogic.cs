using iTrasitionApp.Models;
using iTrasitionApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTrasitionApp.Classes
{
    public static class DBLogic
    {
        //Data Source = tcp:itrasitionappdbserver.database.windows.net,1433;Initial Catalog = iTrasitionApp_db; User Id = Bena2gm@itrasitionappdbserver;Password=870260-Ben2a
        public static string ConnectionString { get; set; }
        public static DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        public static DbContextOptions<ApplicationContext> options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=iTransitionDB;Trusted_Connection=True;")
                    .Options;


        public static Company LoadCompany(int id)
        {

            using (ApplicationContext db = new ApplicationContext(options))
            {
                Company companies = db.Companies.Where(n => n.Id == id).FirstOrDefault(); ;
                db.Users.Load();
                return companies;
            }
        }

        public static void CreateCompany(CreateCompanyModel model)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Company comp = new Company();
                comp.Name = model.Name;
                comp.UserId = model.UserId;
                comp.Description = model.Description;
                comp.UserId = model.UserId;
                comp.Goal = model.Goal;
                comp.Patrons = 0;
                comp.Сurrent = 0;
                comp.Date = DateTime.Now;
                db.Companies.Add(comp);
                db.SaveChanges();
            }
        }

        public static IEnumerable<Company> LoadCompanies()
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                List<Company> company = db.Companies.ToList();
                db.Users.Load();
                return company;

            }
        }
    }
}
