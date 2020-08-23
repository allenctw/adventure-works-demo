using AdventureWorks.Dal;
using AdventureWorks.Service.Interfaces;
using AdventureWorks.Service.Services;
using AdventureWorks.Web.Models.Culture;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [RoutePrefix("{culture}/Culture")]
    [Route("{action=Index}")]
    public class CultureController : BaseController
    {
        private AdventureWorksEntities db = new AdventureWorksEntities();
        private ICultureService cultureService;

        public CultureController()
        {
            cultureService = new CultureService();
        }

        // GET: Culture
        public ActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Cultures = db.Cultures.Select(c => new IndexCulture
                {
                    CultureID = c.CultureID.Trim(),
                    Name = c.Name,
                    ModifiedDate = c.ModifiedDate
                }).ToArray()
            };
            return View(vm);
        }

        // GET: Culture/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var culture = db.Cultures.Find(id);
            if (culture == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel vm = new DetailsViewModel
            {
                CultureID = culture.CultureID.Trim(),
                Name = culture.Name,
                ModifiedDate = culture.ModifiedDate
            };

            return View(vm);
        }

        // GET: Culture/Create
        public ActionResult Create()
        {
            CreateViewModel vm = new CreateViewModel();
            return View(vm);
        }

        // POST: Culture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                Service.Dtos.Culture c = new Service.Dtos.Culture
                {
                    ID = inputModel.CultureID,
                    Name = inputModel.Name
                };
                cultureService.CreateCulture(c);
                return RedirectToAction("Index");
            }

            return View(new CreateViewModel());
        }

        // GET: Culture/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var culture = db.Cultures.Find(id);
            if (culture == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel vm = new DetailsViewModel
            {
                CultureID = culture.CultureID,
                Name = culture.Name,
                ModifiedDate = culture.ModifiedDate
            };

            return View(vm);
        }

        // POST: Culture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                Service.Dtos.Culture c = new Service.Dtos.Culture
                {
                    ID = inputModel.CultureID,
                    Name = inputModel.Name
                };
                cultureService.UpdateCulture(c);
                return RedirectToAction("Index");
            }
            return View(new CreateViewModel());
        }

        // GET: Culture/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var culture = db.Cultures.Find(id);
            if (culture == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel vm = new DetailsViewModel
            {
                CultureID = culture.CultureID,
                Name = culture.Name,
                ModifiedDate = culture.ModifiedDate
            };

            return View(vm);
        }

        // POST: Culture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cultureService.DeleteCulture(id);
            return RedirectToAction("Index");
        }
    }
}
