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

        public ActionResult DetailsBySearch()
        {
            List<EjercicioModel> lEjercicios = new List<EjercicioModel>();
            try
            {
                string toSearch = TempData["ejercicioToSearch"].ToString();
                PersonaModel pModel = new PersonaModel();
                pModel = (PersonaModel)Session["persona" + Session.SessionID];

                EjercicioService eServ = new EjercicioService();
                lEjercicios = eServ.getEjerciciosBySearchFromPersonaId(pModel.id, toSearch);

                return View(lEjercicios);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                TempData["ejercicioToSearch"] = collection["nombre"];
                return RedirectToAction("DetailsBySearch");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicios/Edit/5
        public ActionResult Edit(EjercicioModel ejercicio)
        {
            try
            {
                EjercicioService eServ = new EjercicioService();
                ejercicio = eServ.getEjercicioByID(ejercicio.id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                EjercicioService eServ = new EjercicioService();
                EjercicioModel eModel = new EjercicioModel();

                eModel.id = long.Parse(collection["id"]);
                eModel.nombre = collection["nombre"];
                eModel.tipo = collection["tipo"];
                eModel.urlEjemplo = collection["urlEjemplo"];
                if(collection["tiempo"] == null)
                {
                    eModel.tiempo = null;
                }
                else
                {
                    eModel.tiempo = int.Parse(collection["tiempo"]);
                }
                
                if(collection["repeticiones"] == null)
                {
                    eModel.repeticiones = null;
                }
                else
                {
                    eModel.repeticiones = int.Parse(collection["repeticiones"]);
                }
                eModel.comentarios = collection["comentarios"];
                eModel.intensidad = short.Parse(collection["intensidad"]);

                if( eServ.updateEjercicioByID(eModel) == true )
                {
                    return RedirectToAction("updatedOK");
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicios/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EjercicioModel eModel = new EjercicioModel();
                EjercicioService eServ = new EjercicioService();
                eModel = eServ.getEjercicioByID(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }

        // POST: Ejercicios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                EjercicioService eServ = new EjercicioService();
                if (eServ.deleteEjercicioByID(id) == true)
                {
                    RedirectToAction("deletedOK");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }

        public ActionResult updatedOK()
        {
            return View();
        }
    }
}
