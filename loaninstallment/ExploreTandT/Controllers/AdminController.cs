using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class AdminController : Controller
    {
        DB64Entities db = new DB64Entities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Show the details of all user and packages
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            return View();
        }

        /// <summary>
        /// Show the list of registered tourists 
        /// </summary>
        /// <returns></returns>
        public ActionResult Loanlist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Loan u in db.Loans)
            {
                    user.listofloans.Add(u);
            }
            return View(user);
        }

        public ActionResult employeeloanlist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Loan u in db.Loans)
            {
                user.listofloans.Add(u);
            }
            return View(user);
        }

        public ActionResult loanrequest()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Request u in db.Requests)
            {
                user.requests.Add(u);
            }
            return View(user);
        }


        /// <summary>
        /// Show the list of registered tour guides
        /// </summary>
        /// <returns></returns>
        public ActionResult Employeelist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Employee u in db.Employees)
            {
                    user.listofemployees.Add(u);
            }
            return View(user);
        }

        public ActionResult DeleteLoan(int id)
        {


            var item = db.Loans.Where(x => x.Id == id).SingleOrDefault();
            db.Loans.Remove(item);
            db.SaveChanges();
            string message = "Your product is deleted!";
            return RedirectToAction("Loanlist", "Admin", new { Message = message });


        }

        /// <summary>
        /// Confirmation message to delete the tourist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteTourist(string id)
        {
            return View();
        }

        /// <summary>
        /// Delete the specific Tourist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>
        /// return the updated list
        /// </returns>
        // POST: Tourist/Delete/5
        [HttpPost]
        public ActionResult DeleteTourist(int id, FormCollection collection)
        {
            try
            {

                DB64Entities db = new DB64Entities();
                var item = db.Loans.Where(x => x.Id == id).SingleOrDefault();
                db.Loans.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Touristlist");
            }
            catch
            {
                return View();
            }
        }

 
        /// <summary>
        /// show the add package view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPackages()
        {
            return View();
        }

        /// <summary>
        /// Add the packages in database
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPackages(LoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cmd2 = string.Format("INSERT INTO Loan(Detail,TermsAndConditions,Amount) VALUES('{0}','{1}','{2}')", model.Details, model.TermsAndConditions, model.Amount);
                int rows = Database_Connection.get_instance().Executequery(cmd2);


                // con.Close();

                return RedirectToAction("Dashboard", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


    }

}