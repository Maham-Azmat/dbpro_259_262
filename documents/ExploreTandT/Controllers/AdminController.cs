using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

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
                if (u.Status == 5)
                {
                    user.requests.Add(u);
                }
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
            try
            {
                DB64Entities db = new DB64Entities();
                var item = db.Loans.Where(x => x.Id == id).SingleOrDefault();
                db.Loans.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Loanlist", "Admin");
            }
            catch(Exception ex)
            {
                throw(ex);
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
                string cmd2 = string.Format("INSERT INTO Loan(Detail,TermsAndConditions,Amount,DocumentRequired) VALUES('{0}','{1}','{2}','{3}')", model.Details, model.TermsAndConditions, model.Amount, model.Documentsrequired);
                int rows = Database_Connection.get_instance().Executequery(cmd2);


                // con.Close();

                return RedirectToAction("Dashboard", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult AddPolicy()
        {
            return View();
        }

        /// <summary>
        /// Add the packages in database
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPolicy(int id,PolicyViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LoanId = id;
                string cmd2 = string.Format("INSERT INTO PolicyAndRules(LoanId,Detail,Rank,Salary) VALUES('{0}','{1}','{2}','{3}')",model.LoanId, model.Details, model.Rank, model.Salary);
                int rows = Database_Connection.get_instance().Executequery(cmd2);


                // con.Close();

                return RedirectToAction("Loanlist", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ViewPolicy(int id)
        {
            AdminViewModel user = new AdminViewModel();
            foreach (PolicyAndRule u in db.PolicyAndRules)
            {
                if (u.LoanId == id)
                {
                    user.listOfPolicies.Add(u);
                }
            }
            return View(user);
        }

        public ActionResult DeletePolicy(int id)
        {
            try
            {
                DB64Entities db = new DB64Entities();
                var item2 = db.PolicyAndRules.Where(x => x.Id == id).SingleOrDefault();
                int temp = item2.LoanId;
                var item = db.PolicyAndRules.Where(x => x.Id == id).SingleOrDefault();
                db.PolicyAndRules.Remove(item);
                db.SaveChanges();

                return RedirectToAction("ViewPolicy", "Admin", new { id=temp });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public ActionResult AddInstallments()
        {
            return View();
        }

        /// <summary>
        /// Add the packages in database
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddInstallments(int id,InstallmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LoanId = id;

                string cmd = "SELECT * FROM Loan";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                    {
                        model.Amount = reader.GetInt32(3)/model.Plan;

                    }
                }

                string cmd2 = string.Format("INSERT INTO Installement(LoanId,InstallementPlan,Amount) VALUES('{0}','{1}','{2}')", model.LoanId, model.Plan,model.Amount );
                int rows = Database_Connection.get_instance().Executequery(cmd2);


                // con.Close();

                return RedirectToAction("ViewInstallment", "Admin", new { id = id });
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ViewInstallment(int id)
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Installement u in db.Installements)
            {
                if (u.LoanId == id)
                {
                    user.listOfInstallements.Add(u);
                }
            }
            return View(user);
        }

        public ActionResult DeleteInstallment(int id)
        {
            try
            {

                DB64Entities db = new DB64Entities();
                var item2 = db.Installements.Where(x => x.Id == id).SingleOrDefault();
                int temp = item2.LoanId;
                var item = db.Installements.Where(x => x.Id == id).SingleOrDefault();
                db.Installements.Remove(item);
                db.SaveChanges();

                return RedirectToAction("ViewInstallment", "Admin", new { id = temp });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }

}