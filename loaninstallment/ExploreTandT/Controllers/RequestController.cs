using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.SqlClient;
using ExploreTandT.Models;
namespace ExploreTandT.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        DB64Entities db = new DB64Entities();

        public ActionResult Index(string id)
        {
            try
            {
                Request obj = new Request();
                
                int Id = Int32.Parse(id);
                string userid = User.Identity.GetUserName();
                var person = db.Employees.Where(y => y.Email == userid).First();
                obj.EmployeeId = person.Id;
                obj.LoanId = Id;


                string cmd = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == "Pending")
                    {
                        obj.Status = reader.GetInt32(0);

                    }
                }

                db.Requests.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index", "Account");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
           
        }
        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            UserAccountViewModel user = new UserAccountViewModel();
            RegisterViewModel loggedinuser = new RegisterViewModel();
            
            var person = db.Employees.Where(y => y.Id == id).FirstOrDefault();
            loggedinuser.FirstName = person.FirstName;
            loggedinuser.LastName = person.FirstName;
            loggedinuser.Email = person.Email;
            loggedinuser.Contact = person.Contact;
            loggedinuser.Rank = person.Rank;
            loggedinuser.Salary = person.Salary;
            user.listofusers.Add(loggedinuser);

            return View(user);
            
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
           
               
                var item = db.Requests.Where(x => x.Id == id).SingleOrDefault();
                db.Requests.Remove(item);
                db.SaveChanges();
                string message = "Your product is deleted!";
                return RedirectToAction("loanrequest", "Admin", new { Message = message });
             
            
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
