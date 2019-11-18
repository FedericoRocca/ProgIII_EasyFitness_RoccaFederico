using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;
using Utils;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class RegistryController : Controller
    {
        // GET: Registry
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registry/Details/5
        public ActionResult Registered(PersonaModel _Persona)
        {
            return View();
        }

        // GET: Registry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registry/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                PersonaModel Persona = new PersonaModel();
                Persona.user.mail = collection["user.mail"];
                Persona.user.password = collection["user.password"];
                Persona.nombre = collection["nombre"];
                Persona.apellido = collection["apellido"];
                Persona.dni = int.Parse(collection["dni"]);
                Persona.fechaNacimiento = DateTime.Parse(collection["fechaNacimiento"]);

                UserService uServ = new UserService();
                if(uServ.mailExists( Persona.user.mail ))
                {
                    //El mail ya existe dada de alta en la DDBB!!
                }

                PersonaService pServ = new PersonaService();
                if(pServ.DNIExists( Persona.dni ))
                {
                    //La persona ya existe dada de alta en la DDBB!!
                }

                pServ.altaPersona(Persona);
                pServ.sendUserDataMail(Persona);

                return RedirectToAction("Registered", Persona);
            }
            catch (Exception ex)
            {
                Session["exceptionMessage" + Session.SessionID] = ex.Message;
                Session["exceptionSource" + Session.SessionID] = ex.Source;
                Session["exceptionStackTrace" + Session.SessionID] = ex.StackTrace;
                Session["exceptionTargetSite" + Session.SessionID] = ex.TargetSite;
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Registry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registry/Edit/5
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

        // GET: Registry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registry/Delete/5
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
