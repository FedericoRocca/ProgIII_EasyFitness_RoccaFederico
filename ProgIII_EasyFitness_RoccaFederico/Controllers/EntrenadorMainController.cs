using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgIII_EasyFitness_RoccaFederico.Controllers
{
    public class EntrenadorMainController : Controller
    {
        // GET: EntrenadorMain
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntrenadorMain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntrenadorMain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntrenadorMain/Create
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

        // GET: EntrenadorMain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntrenadorMain/Edit/5
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

        // GET: EntrenadorMain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntrenadorMain/Delete/5
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
