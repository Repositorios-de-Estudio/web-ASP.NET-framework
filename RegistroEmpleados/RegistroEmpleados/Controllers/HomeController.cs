using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroEmpleados.Controllers
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

        public ActionResult Mision()
        {
            // así se enlaza la vista Mision creada
            // para ver agregar el ActionLink es la vista _Layout.cshtml
            // <li>@Html.ActionLink("Mision", "Mision", "Home")</li>
            return View();
        }
    }
}