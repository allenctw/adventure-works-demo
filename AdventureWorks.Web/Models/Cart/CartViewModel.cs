using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Web.Models.Cart
{
    public class CartViewModel : BaseViewModel
    {
        public CartItem[] CartItems { get; set; }
        public decimal Discount { get; set; }
    }
}