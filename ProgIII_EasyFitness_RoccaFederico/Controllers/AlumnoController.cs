﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;
using DataGateway;


namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modificacion()
        {
            return View();
        }

        public ActionResult Datos()
        {
            personaModel persona;
            persona = (personaModel)Session["personaLogedIn" + Session.SessionID];
            return View(persona);
        }

        [HttpPost]
        public ActionResult Datos(FormCollection collection)
        {
            try
            {
                personaModel persona = new personaModel();
                persona = (personaModel)Session["personaLogedIn" + Session.SessionID];

                int oldDNI = persona.dni;
                long oldId = persona.id;
                persona.nombre = Request.Form["nombre"];
                persona.apellido = Request.Form["apellido"];
                persona.dni = int.Parse(Request.Form["dni"]);
                persona.fechaNacimiento = DateTime.ParseExact(Request.Form["fechaNacimiento"], "dd/MM/yyyy", null);
                persona.user.mail = Request.Form["user.mail"];
                persona.user.password = Request.Form["user.password"];
                persona.user.profile = Request.Form["user.profile"];

                personaService pServ = new personaService();
                if(pServ.updatePersonaByIdAndDNI(persona, oldDNI, oldId) == true)
                {
                    return RedirectToAction("ModificacionOK");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
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

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumno/Edit/5
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

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumno/Delete/5
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

        public ActionResult ModificacionOK()
        {
            return View();
        }

    }
}
