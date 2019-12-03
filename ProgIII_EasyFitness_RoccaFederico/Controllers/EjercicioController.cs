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
            personaModel personaLoged = (personaModel)Session["personaLogedIn" + Session.SessionID];
            List<EjercicioModel> ejerciciosPersona = new List<EjercicioModel>();
            EjercicioService ejServ = new EjercicioService();
            ejerciciosPersona = ejServ.getEjerciciosByPersonaID(personaLoged);
            Session["ejercicios" + Session.SessionID] = ejerciciosPersona;

            RutinaService rServ = new RutinaService();
            List<RutinaModel> listRutinas = new List<RutinaModel>();
            listRutinas = rServ.getRutinasByPersonaID(personaLoged);
            Session["rutinas" + Session.SessionID] = listRutinas;
            return View();
        }

        // POST: Ejercicio/Create
        [HttpPost]
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {

                if ((Request.Form["tiempo"] == "" && Request.Form["repeticiones"] == "") ||
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

                if (Request.Form["repeticiones"] != "")
                {
                    ejercicio.repeticiones = int.Parse(Request.Form["repeticiones"]);
                }
                ejercicio.intensidad = Int16.Parse(Request.Form["intensidad"]);
                ejercicio.comentarios = Request.Form["comentarios"].ToString();
                personaModel personaLoged = (personaModel)Session["personaLogedIn" + Session.SessionID];
                ejercicio.idPersona = personaLoged.id;
                ejercicio.idRutina = long.Parse(Request.Form["idRutina"]);

                EjercicioService eServ = new EjercicioService();
                if (eServ.newEjercicio(ejercicio) == false)
                {
                    return RedirectToAction("EjercicioDuplicado");
                }
                else return RedirectToAction("NuevoEjercicio");

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
        public ActionResult NuevoEjercicio()
        {
            return View();
        }

        public ActionResult EjercicioDuplicado()
        {
            return View();
        }
    }
}
