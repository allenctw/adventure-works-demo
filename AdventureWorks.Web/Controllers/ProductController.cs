using AdventureWorks.Dal;
using AdventureWorks.Service.Interfaces;
using AdventureWorks.Service.Services;
using AdventureWorks.Web.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [RoutePrefix("Products")]
    [Route("{action=Index}")]
    public class ProductController : BaseController
    {
        private IProductService productService;

        public ProductController()
        {
            productService = new ProductService();
        }

        // GET: Product
        [Route]
        public ActionResult Index()
        {
            var data = productService.GetProductCatalog("en");
            IndexViewModel vm = new IndexViewModel
            {
                Catalogs = data.Select(d => new IndexProductCatalog
                {
                    ModelName = d.ModelName,
                    ModelDesc = d.ModelDesc,
                    Products = d.Products.Select(p => new IndexProduct
                    {
                        ID = p.ID,
                        Name = p.Name
                    }).ToArray()
                }).ToArray()
            };
            return View(vm);
        }

        // GET: Product/Details/5
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
