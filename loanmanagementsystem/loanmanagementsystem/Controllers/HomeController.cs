using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loanmanagementsystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Database_Connection.get_instance().connectionstring = "Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True";
            //var con = Database_Connection.get_instance().Getconnection();
            //con.Open();

            //catch (Exception ex)
            //{
            //    throw(ex);
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}