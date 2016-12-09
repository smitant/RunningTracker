using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers.GraphingController
{
    public class GraphingController : Controller
    {











        // GET: Graphing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Graphing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Graphing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Graphing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Graphing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Graphing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Graphing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Graphing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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