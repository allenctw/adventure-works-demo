using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Dal;
using AdventureWorks.Service.Dtos;
using AdventureWorks.Web.Models.Culture;

namespace AdventureWorks.Web.Controllers
{
    [RoutePrefix("{culture}/Culture")]
    [Route("{action=Index}")]
    public class CultureController : BaseController
    {
        private AdventureWorksEntities db = new AdventureWorksEntities();

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
                Dal.Culture c = new Dal.Culture
                {
                    CultureID = inputModel.CultureID,
                    Name = inputModel.Name,
                    ModifiedDate = DateTime.Now
                };
                db.Cultures.Add(c);
                db.SaveChanges();
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
                Dal.Culture c = new Dal.Culture
                {
                    CultureID = inputModel.CultureID,
                    Name = inputModel.Name,
                    ModifiedDate = DateTime.Now
                };
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
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
            Dal.Culture culture = db.Cultures.Find(id);
            db.Cultures.Remove(culture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
