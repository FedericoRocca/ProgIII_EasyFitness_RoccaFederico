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

                EntrenamientoService eServ = new EntrenamientoService();
                if (eServ.newEntrenamiento(entrenamiento) == true)
                {
                    return RedirectToAction("NuevoEntrenamiento");
                }
                else
                {
                    return RedirectToAction("ErrorEntrenamiento");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Entrenamiento/Edit/5
        public ActionResult Editar()
        {

            EntrenamientoModel entrenamiento = new EntrenamientoModel();
            EntrenamientoService eServ = new EntrenamientoService();
            personaModel persona = (personaModel)Session["personaLogedIn" + Session.SessionID];
            entrenamiento = eServ.getEntrenamientoByPersonaID(persona);

            return View(entrenamiento);
        }

        // POST: Entrenamiento/Edit/5
        [HttpPost]
        public ActionResult Editar(EntrenamientoModel _entrenamiento)
        {
            try
            {
                EntrenamientoService eServ = new EntrenamientoService();
                if(eServ.updateEntrenamiento(_entrenamiento) == true)
                {
                    return RedirectToAction("EntrenamientoModificado");
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Entrenamiento/Delete/5
        public ActionResult Eliminar()
        {
            EntrenamientoModel entrenamiento = new EntrenamientoModel();
            EntrenamientoService eServ = new EntrenamientoService();
            personaModel persona = (personaModel)Session["personaLogedIn" + Session.SessionID];
            entrenamiento = eServ.getEntrenamientoByPersonaID(persona);

            return View(entrenamiento);
        }

        // POST: Entrenamiento/Delete/5
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                EntrenamientoModel entrenamiento = new EntrenamientoModel();
                EntrenamientoService eServ = new EntrenamientoService();
                entrenamiento = eServ.getEntrenamientoByID(id);

                //Seguir laburando con public bool deleteEntrenamiento(EntrenamientoModel _entrenamiento)

                // Obtengo las rutinas a partir del id de entrenamiento
                // select distinct Rutinas.id from Entrenamientos inner join Rutinas on Entrenamientos.id = Rutinas.idEntrenamiento where Entrenamientos.id = '3'
                // 
                // Obtengo los ejercicios a partir del id de entrenamiento
                // select distinct Ejercicios.id from Entrenamientos
                // inner join Rutinas on Entrenamientos.id = Rutinas.idEntrenamiento
                // inner join Ejercicios on Rutinas.id = Ejercicios.idRutina
                // where Entrenamientos.id = '3'

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NuevoEntrenamiento()
        {
            return View();
        }

        public ActionResult ErrorEntrenamiento()
        {
            return View();
        }

        public ActionResult ListaEntrenamientos()
        {

            personaModel persona = (personaModel)Session["personaLogedIn" + Session.SessionID];
            List<EntrenamientoModel> listaEntrenamientos = new List<EntrenamientoModel>();
            EntrenamientoService eServ = new EntrenamientoService();
            listaEntrenamientos = eServ.getEntrenamientosByPersonaID(persona);

            return View(listaEntrenamientos);
        }
        public ActionResult EntrenamientoModificado()
        {
            return View();
        }
        
    }
}
