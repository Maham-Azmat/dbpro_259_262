using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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
        public ActionResult Payloan()
        {
            return View();
        }

        public ActionResult ViewDocument()
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

        public ActionResult Listofdocuments()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Document u in db.Documents)
            {
                user.listOfDocumentstobeverified.Add(u);
            }
            return View(user);
        }

        public ActionResult Verifydocument(int eid, int lid, string title)
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Document u in db.Documents)
            {
                if (u.EmployeeId == eid && u.LoanId == lid)
                {
                    user.listOfDocumentstobeverified.Add(u);
                }
            }
            return View(user);
        }
       
        public ActionResult Verify( int eid, int lid, DocumentViewModel model)
        {
                string cmd = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == "Verified")
                    {
                        model.Status = reader.GetInt32(0);

                    }
                }
                EmployeeLoan ob = new EmployeeLoan();
                string cmmd = "SELECT * FROM Lookup";
                SqlDataReader readerrr = Database_Connection.get_instance().Getdata(cmmd);
                while (readerrr.Read())
                {
                    if (readerrr.GetString(1) == "Approve")
                    {
                        ob.Status = readerrr.GetInt32(0);

                    }
                }

                string cmd3 = string.Format("UPDATE  Document SET Status = '{0}' WHERE  EmployeeId= '{1}' AND LoanId= '{2}'", model.Status, eid, lid);
                int rows = Database_Connection.get_instance().Executequery(cmd3);
                string cmd4 = string.Format("UPDATE  EmployeeLoan SET Status = '{0}' WHERE  EmployeeId= '{1}' AND LoanId= '{2}'", ob.Status , eid, lid);
                int row = Database_Connection.get_instance().Executequery(cmd4);

                return RedirectToAction("Listofdocuments", "Admin");
            

        }


        public ActionResult NotVerify(int eid, int lid, DocumentViewModel model)
        {
            string cmd = "SELECT * FROM Lookup";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            while (reader.Read())
            {
                if (reader.GetString(1) == "Disapprove")
                {
                    model.Status = reader.GetInt32(0);

                }
            }

            string cmd3 = string.Format("UPDATE  Document SET Status = '{0}' WHERE  EmployeeId= '{1}' AND LoanId= '{2}'", model.Status, eid, lid);
            int rows = Database_Connection.get_instance().Executequery(cmd3);
            return RedirectToAction("Listofdocuments", "Admin");


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

        public ActionResult EmployeeLoan()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (EmployeeLoan u in db.EmployeeLoans)
            {
                if (u.Status == 1)
                {
                    user.listofEmployeeLoan.Add(u);
                }
            }
            return View(user);
        }

        public ActionResult AddRepaymentSchedule(int id,int eid,int insid)
        {
            int instId;
            int instPlan;
            foreach (RepaymentSchedule d in db.RepaymentSchedules)
            {
                if (d.EmployeeId ==eid  && d.InstallementId == insid)
                {
                    TempData["msg"] = "<script>alert('Repayment Schedule for this particular Employee loan is already generated.');</script>";
                    return RedirectToAction("EmployeeLoan", "Admin");
                }
            }
            foreach (EmployeeLoan u in db.EmployeeLoans)
            {
                if (u.Id == id)
                {
                    instId = u.InstallementId;
                    foreach (Installement i in db.Installements)
                    {
                        if (i.Id == instId)
                        {
                            int j = 0;
                            instPlan = i.InstallementPlan;
                            while (instPlan != 0)
                            {
                                RepaymentSchedule obj = new RepaymentSchedule();
                                obj.EmployeeId = u.EmployeeId;
                                obj.InstallementId = i.Id;
                                obj.Amount = i.Amount;
                                obj.Date = DateTime.Now.Date.AddMonths(j);
                                string cmdd = "SELECT * FROM Lookup";
                                SqlDataReader readerr = Database_Connection.get_instance().Getdata(cmdd);
                                while (readerr.Read())
                                {
                                    if (readerr.GetString(1) == "Due")
                                    {
                                        obj.Status = readerr.GetInt32(0);

                                    }
                                }
                                SqlConnection cn = new SqlConnection(@"Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("INSERT INTO RepaymentSchedule(EmployeeId,InstallementId,Amount,Date,Status) VALUES (@eid,@iid,@amount,@date,@status)", cn);
                                cmd.Parameters.AddWithValue("@eid", obj.EmployeeId);
                                cmd.Parameters.AddWithValue("@iid", obj.InstallementId);
                                cmd.Parameters.AddWithValue("@amount", obj.Amount);
                                cmd.Parameters.AddWithValue("@date", obj.Date);
                                cmd.Parameters.AddWithValue("@status", obj.Status);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                cn.Close();
                                
                                j++;
                                instPlan--;
                            }

                        }
                    }
                }
            }
            return RedirectToAction("RepaymentSchedule", "Admin");
        }

        public ActionResult RepaymentSchedule()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (RepaymentSchedule r in db.RepaymentSchedules)
            {
                user.listOfRepaymentSchedule.Add(r);
            }
            return View(user);
        }


    }

}