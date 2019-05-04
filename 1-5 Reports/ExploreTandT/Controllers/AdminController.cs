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
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

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
        /// Show the details of all tasks that can be performed by admin
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            //If admin is login than go to dashboard else go to login page
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// Give view containing a button through which Admin pays loan amount to employee using paypal
        /// </summary>
        /// <returns></returns>
        public ActionResult Payloan()
        {
            return View();
        }

        /// <summary>
        /// show list of documents
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewDocument()
        {
            return View();
        }


        /// <summary>
        /// show loan list
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

        /// <summary>
        /// show list of employees
        /// </summary>
        /// <returns></returns>
        public ActionResult employeeloanlist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Loan u in db.Loans)
            {
                user.listofloans.Add(u);
            }
            return View(user);
        }

        /// <summary>
        /// show list of documents
        /// </summary>
        /// <returns></returns>
        public ActionResult Listofdocuments()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (Document u in db.Documents)
            {
                if (u.Status != 9)
                {
                    user.listOfDocumentstobeverified.Add(u);
                }
            }
            return View(user);
        }

        /// <summary>
        /// Move to the list of document's for a particular loan which are to be verified
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="lid"></param>
        /// <param name="title"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verify Documents from the list
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="lid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Does not verify document's in case they are not correct
        /// </summary>
        /// <param name="eid"></param>
        /// <param name="lid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Show pending request's for loan
        /// </summary>
        /// <returns></returns>
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
        /// show employee's list
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

        /// <summary>
        /// show policyAndRules list
        /// </summary>
        /// <returns></returns>
        public ActionResult PolicyAndRulelist()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (PolicyAndRule u in db.PolicyAndRules)
            {
                user.listOfPolicies.Add(u);
            }
            return View(user);
        }

        /// <summary>
        /// Download PDF of all employees
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportEmployees()
        {
            List<Employee> allCustomer = new List<Employee>();
            allCustomer = db.Employees.ToList();


            CrystalReport1 rd = new CrystalReport1();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeList.pdf");
        }

        /// <summary>
        /// Download PDF of all loans
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportLoans()
        {
            List<Loan> allCustomer = new List<Loan>();
            allCustomer = db.Loans.ToList();


            CrystalReport2 rd = new CrystalReport2();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Loanlist.pdf");
        }

        /// <summary>
        /// Download PDF of Loans Assigned to employees
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportEmployeeLoans()
        {
            List<EmployeeLoan> allCustomer = new List<EmployeeLoan>();
            allCustomer = db.EmployeeLoans.ToList();


            CrystalReport3 rd = new CrystalReport3();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeLoan.pdf");
        }

        /// <summary>
        /// Download PDF of Policy and rules
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportPolicyAndRules()
        {
            List<PolicyAndRule> allCustomer = new List<PolicyAndRule>();
            allCustomer = db.PolicyAndRules.ToList();


            CrystalReport4 rd = new CrystalReport4();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "PolicyAndRulelist.pdf");
        }

        /// <summary>
        /// Download PDF of loan's installments
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportLoanInstallments()
        {
            List<Installement> allCustomer = new List<Installement>();
            allCustomer = db.Installements.ToList();


            CrystalReport5 rd = new CrystalReport5();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ViewInstallment.pdf");
        }

        /// <summary>
        /// Download PDF of employee's salary deduction
        /// </summary>
        /// <returns></returns>
        public ActionResult Export7()
        {
            List<SalaryDeduction> allCustomer = new List<SalaryDeduction>();
            allCustomer = db.SalaryDeductions.ToList();


            CrystalReport7 rd = new CrystalReport7();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "SalaryDeductionList.pdf");
        }

        /// <summary>
        /// Download PDF of employees Repayment Schedule
        /// </summary>
        /// <returns></returns>
        public ActionResult Export6()
        {
            List<RepaymentSchedule> allCustomer = new List<RepaymentSchedule>();
            allCustomer = db.RepaymentSchedules.ToList();


            CrystalReport6 rd = new CrystalReport6();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);
            
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "InsatllmentstatusList.pdf");
        }

        /// <summary>
        /// Download PDF of all requests of employees for loans
        /// </summary>
        /// <returns></returns>
        public ActionResult Export8()
        {
            List<Request> allCustomer = new List<Request>();
            allCustomer = db.Requests.ToList();


            CrystalReport8 rd = new CrystalReport8();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeloanrequestList.pdf");
        }

        /// <summary>
        /// Download PDF of all employees loan status
        /// </summary>
        /// <returns></returns>
        public ActionResult Export9()
        {
            List<EmployeeLoan> allCustomer = new List<EmployeeLoan>();
            allCustomer = db.EmployeeLoans.ToList();


            CrystalReport9 rd = new CrystalReport9();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeloanList.pdf");
        }

        /// <summary>
        /// Download PDF of all employees paid installments
        /// </summary>
        /// <returns></returns>
        public ActionResult Export10()
        {
            List<vwpaidinstallment> allCustomer = new List<vwpaidinstallment>();
            allCustomer = db.vwpaidinstallments.ToList();


            CrystalReport6 rd = new CrystalReport6();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportCustomer.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "PaidEmployeeloanList.pdf");
        }

        /// <summary>
        /// Delete Loan
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// show the add loan package view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPackages()
        {
            return View();
        }

        /// <summary>
        /// Add the loan packages in database
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

        /// <summary>
        /// show view of add loan policy
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPolicy()
        {
            return View();
        }

        /// <summary>
        /// Add particular loan PolicyAndRules in database
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

        /// <summary>
        /// View list of particular loan's policyAndRules
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete policyAndRules from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Show view of add loan installment
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInstallments()
        {
            return View();
        }

        /// <summary>
        /// Add particular loan's installements in database
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

        /// <summary>
        /// View Loan Installment's list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete installment from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Show list of EmployeeLoan's
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Add repayment schedule for approved loan's in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eid"></param>
        /// <param name="insid"></param>
        /// <param name="lid"></param>
        /// <returns></returns>
        public ActionResult AddRepaymentSchedule(int id,int eid,int insid, int lid)
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
                            //add installments list with number of installment's selected and monthly date
                            while (instPlan != 0)
                            {
                                RepaymentSchedule obj = new RepaymentSchedule();
                                obj.EmployeeId = u.EmployeeId;
                                obj.InstallementId = i.Id;
                                obj.LoanId = i.LoanId;
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
                                //Insert in repaymentSchedule table in database
                                SqlConnection cn = new SqlConnection(@"Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                                cn.Open();
                                SqlCommand cmd = new SqlCommand("INSERT INTO RepaymentSchedule(EmployeeId,InstallementId,LoanId,Amount,Date,Status) VALUES (@eid,@iid,@lid,@amount,@date,@status)", cn);
                                cmd.Parameters.AddWithValue("@eid", obj.EmployeeId);
                                cmd.Parameters.AddWithValue("@iid", obj.InstallementId);
                                cmd.Parameters.AddWithValue("@lid", obj.LoanId);
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

        /// <summary>
        /// Show repayment schedule's list of employees
        /// </summary>
        /// <returns></returns>
        public ActionResult RepaymentSchedule()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (RepaymentSchedule r in db.RepaymentSchedules)
            {
                user.listOfRepaymentSchedule.Add(r);
            }
            return View(user);
        }

        /// <summary>
        /// deduct salary of employee monthly
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lid"></param>
        /// <param name="inid"></param>
        /// <param name="eid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SalaryDeduct(DateTime date, int lid, int inid, int eid, int id)
        {
            foreach(RepaymentSchedule s in db.RepaymentSchedules)
            {
                if (s.Status==6 && s.EmployeeId==eid && s.LoanId==lid && s.InstallementId==inid && s.Id==id)
                {
                    TempData["msg"] = "<script>alert('Salary Deduction for this particular Employee loan is already done.');</script>";
                    return RedirectToAction("EmployeeLoan", "Admin");
                }
            }
           
            SalaryDeduction obj = new SalaryDeduction();
            int tempamount = 0;
            string cmd0 = "SELECT * FROM RepaymentSchedule";
            SqlDataReader reader0 = Database_Connection.get_instance().Getdata(cmd0);
            while (reader0.Read())
            {
                if (reader0.GetInt32(0) == eid && reader0.GetInt32(1) == inid)
                {
                    tempamount = reader0.GetInt32(2);
                    
                    break;

                }
            }
            obj.Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(date.Month);
            //if (date.Month == 01)
            //    obj.Month = "January";
            //else if (date.Month == 02)
            //    obj.Month = "Feburary";
            //else
            var person = db.Employees.Where(y => y.Id == eid).First();
            int temp = person.Salary;
            obj.SalaryAfterDeduction = person.Salary - tempamount ;
            obj.LoanId = lid;
            obj.InstallementId = inid;
            obj.EmployeeId = eid;
            obj.Date = DateTime.Now;
            
            SqlConnection cn = new SqlConnection(@"Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            cn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO SalaryDeduction(EmployeeId,InstallementId,LoanId,SalaryAfterDeduction,Date,Month) VALUES (@eid,@inid,@lid,@amount,@date,@month)", cn);
            cmd.Parameters.AddWithValue("@eid", obj.EmployeeId);
            cmd.Parameters.AddWithValue("@inid", obj.InstallementId);
            cmd.Parameters.AddWithValue("@lid", obj.LoanId);
            cmd.Parameters.AddWithValue("@amount", obj.SalaryAfterDeduction);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@month",obj.Month);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

            //now updating status in repayment schedule table
            RepaymentSchedule model = new RepaymentSchedule();
            string cmd1 = "SELECT * FROM Lookup";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd1);
            while (reader.Read())
            {
                if (reader.GetString(1) == "Paid")
                {
                    model.Status = reader.GetInt32(0);

                }
            }

            string cmd3 = string.Format("UPDATE  RepaymentSchedule SET Status = '{0}' WHERE  EmployeeId= '{1}' AND LoanId= '{2}' AND InstallementId= '{3}' AND Id= '{4}'", model.Status, eid, lid, inid,id);
            int rows = Database_Connection.get_instance().Executequery(cmd3);
            return RedirectToAction("RepaymentSchedule", "Admin");

        }

        /// <summary>
        /// Show list of salary Deduction
        /// </summary>
        /// <returns></returns>
        public ActionResult SalaryDeductionList()
        {
            AdminViewModel user = new AdminViewModel();
            foreach (SalaryDeduction u in db.SalaryDeductions)
            {
               
                    user.Salarydeductlist.Add(u);
                
            }
            return View(user);
        }




    }

}