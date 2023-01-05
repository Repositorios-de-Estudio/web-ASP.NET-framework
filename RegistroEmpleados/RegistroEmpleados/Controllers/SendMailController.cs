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
                // remitente divide el nombre de usuario del dominio
                string[] remitente = mailWEB.Desde.Split('@');

                MailAddress desde = new MailAddress(mailWEB.Desde);
                MailAddress hacia = new MailAddress(mailWEB.Hacia);
                MailMessage mensaje = new MailMessage(desde, hacia);
                mensaje.Subject = mailWEB.Asunto;
                mensaje.Body = mailWEB.Cuerpo;
                mensaje.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "192.168.0.20";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(remitente[0], "Contraseña1234", remitente[1]);
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