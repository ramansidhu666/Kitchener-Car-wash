using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CarWash_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpPost]
        public ActionResult Contact(string username, string subject, string Email, string phn, string message)
        {
            SendMail(username , Email, phn,subject, message);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
       
        public bool SendMail(string Name, string Email , string Phone,string subject, string Message = "")
        {

            MailMessage message = new MailMessage();
            message.To.Add(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.Subject = subject;

            string body = "";
            body = "<p>Person Name : " + Name + "</p>";
            body = body + "<p>Email ID : " + Email + "</p>";
          
                body = body + "<p>Phone No : " + Phone + "</p>";
             body = body + "<p>Message : " + message + "</p>";
           
               
           
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.ionos.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;

        }

        public ActionResult Car_Wash_packages()
        {
            return View();
        }
        public ActionResult details()
        {
            return View();
        }
        public ActionResult faqs()
        {
            return View();
        }
        public ActionResult hiring()
        {
            return View();
        }
        public ActionResult hot_sale()
        {
            return View();
        }
    }
}