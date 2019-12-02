using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class RutinaController : Controller
    {
        // GET: Rutina
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rutina/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rutina/Create
        public ActionResult Nueva()
        {

            personaModel personaLoged = (personaModel)Session["personaLogedIn" + Session.SessionID];
            List<EntrenamientoModel> entrenamientosPersona = new List<EntrenamientoModel>();
            EntrenamientoService eServ = new EntrenamientoService();

            entrenamientosPersona = eServ.getEntrenamientosByPersonaID(personaLoged);

            Session["entrenamientos" + Session.SessionID] = entrenamientosPersona;

            return View();
        }

        // POST: Rutina/Create
        [HttpPost]
        public ActionResult Nueva(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rutina/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rutina/Edit/5
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

        // GET: Rutina/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rutina/Delete/5
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
