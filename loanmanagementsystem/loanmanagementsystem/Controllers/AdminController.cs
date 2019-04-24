using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loanmanagementsystem.Models;

namespace loanmanagementsystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {      
            return View();
        }

        public ActionResult AddPackages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPackages(LoanViewModels model)
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