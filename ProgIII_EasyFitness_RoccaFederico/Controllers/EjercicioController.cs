using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class EjercicioController : Controller
    {
        // GET: Ejercicio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ejercicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio/Create
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Ejercicio/Create
        [HttpPost]
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {

                if((Request.Form["tiempo"] == "" && Request.Form["repeticiones"] == "") || 
                   (int.Parse(Request.Form["tiempo"]) <= 0 && int.Parse(Request.Form["repeticiones"]) <= 0))
                {

                }

                EjercicioModel ejercicio = new EjercicioModel();
                ejercicio.nombre = Request.Form["nombre"].ToString();
                ejercicio.tipo = Request.Form["tipo"].ToString();
                ejercicio.urlEjemplo = Request.Form["urlEjemplo"].ToString();
                var asd = Request.Form["tiempo"];
                if (Request.Form["tiempo"] != "")
                {
                    ejercicio.tiempo = int.Parse(Request.Form["tiempo"]);
                }

                if(Request.Form["repeticiones"] != "")
                {
                    ejercicio.repeticiones = int.Parse(Request.Form["repeticiones"]);
                }
                ejercicio.intensidad = Int16.Parse(Request.Form["intensidad"]);
                


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio/Edit/5
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

        // GET: Ejercicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
