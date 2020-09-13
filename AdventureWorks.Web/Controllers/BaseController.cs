using AdventureWorks.Dal;
using AdventureWorks.Service.Interfaces;
using AdventureWorks.Service.Services;
using AdventureWorks.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ICultureService cultureService;
        protected string currentCulture;

        public BaseController(IDbRepository<Culture> cultureRepo)
        {
            cultureService = new CultureService(cultureRepo);
            currentCulture = "en";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cultures = cultureService.GetCultureIDs();
            string culture = (string)filterContext.RouteData.Values["culture"];
            if(string.IsNullOrEmpty(culture) || !cultures.Contains(culture))
            {
                filterContext.Result = new HttpStatusCodeResult(404);
            }
            currentCulture = culture;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var cultures = cultureService.GetCultures();
                if(filterContext.Controller.ViewData.Model == null)
                {
                    filterContext.Controller.ViewData.Model = new BaseViewModel();
                }
                var baseViewModel = (BaseViewModel)filterContext.Controller.ViewData.Model;
                baseViewModel.Cultures = cultures.Select(c => new BaseCulture
                {
                    ID = c.ID,
                    Name = c.Name
                }).ToArray();
            }
        }
    }
}