using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgressBarSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetProgressStatus(int time)
        {
            return Json(new
            {
                value = time + 4
            });
        }
    }
}