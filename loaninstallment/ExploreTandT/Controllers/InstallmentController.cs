using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExploreTandT.Models;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ExploreTandT.Controllers
{
    public class InstallmentController : Controller
    {
        // GET: Installment
        public ActionResult Index()
        {
            return View();
        }
        static int Id = 0;
        public ActionResult AddInstallment(int id)
        {
            TempData["Loanid"] = id;
            Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddInstallment(InstallmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                int temp=0;
                
                string cmd = "SELECT * FROM Loan";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == Id)
                    {
                        temp = reader.GetInt32(3);

                    }
                }
                model.Amount = temp/model.Installmentplan;
                string cmd2 = string.Format("INSERT INTO Installement(LoanId,InstallementPlan,Amount) VALUES('{0}','{1}','{2}')", Id, model.Installmentplan, model.Amount);
                int rows = Database_Connection.get_instance().Executequery(cmd2);


                // con.Close();

                return RedirectToAction("Loanlist", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        // GET: Installment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Installment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Installment/Create
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

        // GET: Installment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Installment/Edit/5
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

        // GET: Installment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Installment/Delete/5
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
