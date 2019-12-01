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
    public class EntrenamientoController : Controller
    {
        // GET: Entrenamiento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Entrenamiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entrenamiento/Create
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Entrenamiento/Create
        [HttpPost]
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {
                EntrenamientoModel entrenamiento = new EntrenamientoModel();
                entrenamiento.descripcion = Request.Form["descripcion"];
                entrenamiento.nombre = Request.Form["nombre"];
                entrenamiento.idPersona = ((personaModel)Session["personaLogedIn" + Session.SessionID]).id;

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entrenamiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entrenamiento/Edit/5
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

        // GET: Entrenamiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entrenamiento/Delete/5
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
