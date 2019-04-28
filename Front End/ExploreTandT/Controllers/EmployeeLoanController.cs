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
using System.IO;

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
        List<string> temp2 = new List<string>();

        public ActionResult AddDocuments(int id, int lid)
        {
            DocumentViewModel collection = new DocumentViewModel();
           
            var item = db.Loans.Where(x => x.Id == id).SingleOrDefault();
            string temp=item.DocumentRequired;
            string t = null;
            collection.Document = temp;
            foreach (char tr in temp)
            {
                if (tr != ',')
                {
                    t = t + tr.ToString();

                }
                else
                {
                    temp2.Add(t);
                  

                }

            }
            temp2.Add(t);
            t = null;
            collection.temp= temp2.Count();
            return View(collection);
        }

        [HttpPost]

        public ActionResult AddDocuments(int id, int lid, DocumentViewModel model)
        {
            model.temp = temp2.Count();
            string userid = User.Identity.GetUserName();
            var person = db.Employees.Where(y => y.Email == userid).First();
            foreach (var i in temp2)
            {
                Document obj = new Document();
                obj.Title = i;
               
                obj.EmployeeId = person.Id;

                string cmd = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == "NotVerified")
                    {
                        obj.Status = reader.GetInt32(0);

                    }
                }

                string fileName = Path.GetFileName(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.Document = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);
                obj.RequiredDocuments = model.Document;
                db.Documents.Add(obj);
                db.SaveChanges();
            }

            string cmd2 = string.Format("INSERT INTO EmployeeLoan(EmployeeId,LoanId,InstallementId,Status) VALUES('{0}','{1}','{2}','{3}')", person.Id, id, lid,2);
            int rows = Database_Connection.get_instance().Executequery(cmd2);
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
