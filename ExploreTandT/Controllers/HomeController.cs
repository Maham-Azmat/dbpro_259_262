﻿using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class HomeController : Controller
    {
        ExploreEntities db = new ExploreEntities();
        public ActionResult Index()
        {
            Database_Connection.get_instance().connectionstring = "Data Source=HAIER-PC;Initial Catalog=DB64;Integrated Security=True";
            var con = Database_Connection.get_instance().Getconnection();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// View the contact page 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// COntact us all functionality done in this function
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel collection)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("exploretoursguide@gmail.com")); 
            message.From = new MailAddress(collection.Email);  
            message.Subject ="Explore Contact";
            message.Body = string.Format(collection.Body, "model.FromName", "model.FromEmail", "model.Message");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "exploretoursguide@gmail.com",  
                    Password = "admin-123"  
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return Redirect("Index");
            }
        }
    }
}