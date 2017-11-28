using System.Web.Mvc;

namespace ProgressBarSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _progressKey = "PROGRESS";

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: Do some DB operations here and save it in some storage
        [HttpPost]
        public JsonResult StartSomeDbOperation()
        {
            var percentCompleted = 0;
            Session[_progressKey] = percentCompleted;

            return Json(new
            {
                status = true,
                percentCompleted = percentCompleted
            });
        }

        // POST: Keep on getting percent of work completed from storage
        [HttpPost]
        public JsonResult GetProgressStatus()
        {
            int percentCompleted = 0;
            if (Session[_progressKey] != null)
            {
                percentCompleted = (int)Session[_progressKey];
                percentCompleted += 4;
                Session[_progressKey] = percentCompleted;
                if(percentCompleted >= 100)
                {
                    Session.Remove(_progressKey);
                }

            }

            return Json(new
            {
                percentCompleted = percentCompleted
            });
        }
       
    }
}