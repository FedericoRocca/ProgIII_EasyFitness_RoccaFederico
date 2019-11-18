using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class EjerciciosController : Controller
    {
        // GET: Ejercicios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ejercicios/Details/5
        public ActionResult Details()
        {
            List<EjercicioModel> lEjercicios = new List<EjercicioModel>();
            try
            {
                PersonaModel pModel = new PersonaModel();
                pModel = (PersonaModel)Session["persona" + Session.SessionID];

                EjercicioService eServ = new EjercicioService();
                lEjercicios = eServ.getEjerciciosByPersonaID( pModel.id );
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(lEjercicios);
        }

        // GET: Ejercicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Ejercicios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicios/Edit/5
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

        // GET: Ejercicios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicios/Delete/5
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
