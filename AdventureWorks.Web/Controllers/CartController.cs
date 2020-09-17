using AdventureWorks.Dal;
using AdventureWorks.Web.Models.Cart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    [RoutePrefix("{culture}/Cart")]
    [Route("{action=Index}")]
    public class CartController : BaseController
    {
        public CartController(IDbRepository<Culture> cultureRepo) : base(cultureRepo) { }

        // GET: Cart
        public ActionResult Index()
        {
            var vm = new CartViewModel();
            var reqCookie = Request.Cookies.Get("CartItems");
            vm.CartItems = JsonConvert.DeserializeObject<CartItem[]>(reqCookie.Value);
            return View(vm);
        }

        [HttpPost]
        public JsonResult AddToCart(CartItem cartItem)
        {
            var reqCookie = Request.Cookies.Get("CartItems");
            if (reqCookie == null)
            {
                List<CartItem> items = new List<CartItem> { cartItem };
                var sItems = JsonConvert.SerializeObject(items);
                HttpCookie cookie = new HttpCookie("CartItems", sItems);
                Response.Cookies.Add(cookie);
            }
            else
            {
                var items = JsonConvert.DeserializeObject<List<CartItem>>(reqCookie.Value);
                items.Add(cartItem);
                var sItems = JsonConvert.SerializeObject(items);
                reqCookie.Value = sItems;
                Response.Cookies.Set(reqCookie);
            }
            var result = new JsonResult();
            result.Data = new { success = true };
            return result;
        }
    }
}