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

        /// <summary>
        /// Show pending request's to admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// accept or reject request and give reason
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eid"></param>
        /// <param name="lid"></param>
        /// <returns></returns>
        public ActionResult Details(int id, int eid, int lid)
        {
            UserAccountViewModel user = new UserAccountViewModel();
            RegisterViewModel loggedinuser = new RegisterViewModel();
            RequestViewModel req = new RequestViewModel();
            LoanViewModel l = new LoanViewModel();
            var request = db.Requests.Where(y => y.Id == id).FirstOrDefault();
            var person = db.Employees.Where(y => y.Id == eid).FirstOrDefault();
            var loan = db.Loans.Where(y => y.Id == lid).FirstOrDefault();
            //if third part of employee's salary is greater or equal to loan amount divided by 12 then request is accepted else rejected
            if (person.Salary / 3 >= loan.Amount / 12)
            {

                request.Status = 3;
                user.Details = "Request is accepted because salary fulfills the policy of this loan";
                req.Reason = user.Details;
                request.Details = req.Reason;
                
            }
            else
            {
                request.Status = 4;
                user.Details = "Request is rejected because salary does not fulfill the policy of this loan";
                request.Details = user.Details;
            }

            SqlConnection cn = new SqlConnection(@"Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            cn.Open();
            string sql = "UPDATE Request SET Status='" + request.Status + "',Details='" + user.Details + "'WHERE Id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

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

    }
}
