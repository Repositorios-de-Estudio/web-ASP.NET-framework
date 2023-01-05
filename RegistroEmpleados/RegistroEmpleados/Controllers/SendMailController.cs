using RegistroEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RegistroEmpleados.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(MailModel mailWEB)
        {
            if (ModelState.IsValid)
            {
                MailAddress desde = new MailAddress("FromAddress");
                MailAddress hacia = new MailAddress("ToAddress");
                MailMessage mensaje = new MailMessage(desde, hacia);
                mensaje.Subject = "testmail";
                mensaje.Body = "testmail";
                mensaje.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Port = ;
                client.Host = "exchange server host address";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("username", "password", "domain");
                client.Send(mensaje);

                return View("Index", mailWEB);
            }
            else
            {
                return View();
            }
        }
    }
}