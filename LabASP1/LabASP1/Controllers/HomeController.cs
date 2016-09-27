using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabASP1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta aplicacion es una prueba del laboratorio para el curso de Ingenieria de Sistemas.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Mejor no nos contacte, esto solamente es una prueba.";

            return View();
        }
    }
}