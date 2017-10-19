using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingTool.Controllers
{
    public class TestLevelsController : Controller
    {
        // GET: TestLevels

        public ActionResult LevelDetails(string parentID)
        {
            ViewBag.parentID = parentID;
            
            return View("LevelDetails");
        }
    }
}