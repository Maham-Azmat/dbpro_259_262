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
    public class EmployeeLoanController : Controller
    {
        // GET: EmployeeLoan
        DB64Entities db = new DB64Entities();

        public ActionResult Index(int id)
        {
            LoanViewModel req = new LoanViewModel();

            foreach (Loan e in db.Loans)
            {
                if (e.Id == id)
                {
                    req.listofloans.Add(e);
                    req.TermsAndConditions = e.TermsAndConditions;
                }
            }


            return View(req);
        }

        public ActionResult Installment(int id)
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

        public ActionResult AddDocuments(int id)
        {
            return View();
        }

        // GET: EmployeeLoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeLoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeLoan/Create
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

        // GET: EmployeeLoan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeLoan/Edit/5
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

        // GET: EmployeeLoan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeLoan/Delete/5
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
