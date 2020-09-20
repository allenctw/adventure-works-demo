using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service.DiscountCore
{
    public class RebateStrategy : IDiscountStrategy
    {
        private decimal everyPurchase;
        private decimal rebate;

        public RebateStrategy(decimal everyPurchase = 1000, decimal rebate = 100)
        {
            this.everyPurchase = everyPurchase;
            this.rebate = rebate;
        }

        public decimal CalculateDiscount(List<Product> products)
        {
            var discount = 0m;
            if (products != null)
            {
                decimal total = products.Sum(p => p.Qty * p.Price);
                discount = (int)(total / everyPurchase) * rebate;
            }
            return Math.Round(discount, 2);
        }
    }
}
