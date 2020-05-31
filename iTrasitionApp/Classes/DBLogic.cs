using iTrasitionApp.Models;
using iTrasitionApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace iTrasitionApp.Classes
{
    public class DBLogic : IDisposable
    {
        private ApplicationContext db;

        public DBLogic(ApplicationContext context)
        {
            db = context;
        }

        public Company LoadCompanyByID(int id)
        {
            Company companies = db.Companies.Where(n => n.Id == id).FirstOrDefault(); ;
            db.Users.Load();
            db.Comments.Load();
            return companies;
        }

        public void CreateCompany(CreateCompanyModel model)
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

        public IEnumerable<Company> LoadCompany()
        {
            List<Company> company = db.Companies.ToList();
            db.Users.Load();
            return company;
        }


        public IEnumerable<Company> LoadCompany(string userId)
        {
            List<Company> company = db.Companies.Where(c => c.UserId == userId).ToList();
            db.Users.Load();
            return company;
        }

        public void AddComment(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public void Like(int id)
        {
            Company toUpdate = db.Companies.Find(id);
            if (toUpdate != null)
            {
                toUpdate.Patrons++;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
