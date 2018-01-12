using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingTool.Controllers.Pages
{
    public class TestSetsController : Controller
    {
        // GET: TestSets
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestSets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult TestSetMappings(Guid TestSet_IDNumber)
        {
            ViewBag.TestSet_IDNumber = TestSet_IDNumber;

            return View("TestSetMappings");
        }
        // GET: TestSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestSets/Create
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

        // GET: TestSets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestSets/Edit/5
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

        // GET: TestSets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestSets/Delete/5
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
