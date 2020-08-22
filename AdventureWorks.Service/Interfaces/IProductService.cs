using AdventureWorks.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service.Interfaces
{
    public interface IProductService
    {
        ProductCatalog[] GetProductCatalog(string cultureID);
    }
}
