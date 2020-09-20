using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service.DiscountCore
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(List<Product> products);
    }
}
