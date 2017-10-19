using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingTool.Controllers
{
    public class TestsController : Controller
    {
        // GET: TestLevels

        public ActionResult TestCaseDetails(Guid Structure_IDNumber)
        {
            ViewBag.Structure_IDNumber = Structure_IDNumber;
            
            return View("TestCaseDetails");
        }
    }
}