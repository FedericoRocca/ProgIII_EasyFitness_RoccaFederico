using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class EjercicioController : Controller
    {
        // GET: Ejercicio
        public ActionResult Lista()
        {
            return View();
        }
    }
}