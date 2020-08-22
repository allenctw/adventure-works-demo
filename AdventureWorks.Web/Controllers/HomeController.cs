using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class HomeController : BaseController
    {
        [Route("{culture}")]
        public ActionResult Index()
        {
            return View();
        }


        [Route("{culture}/About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("{culture}/Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}