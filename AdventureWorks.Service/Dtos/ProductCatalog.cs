using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Service.Dtos
{
    public class ProductCatalog
    {
        public string ModelName { get; set; }
        public string ModelDesc { get; set; }
        public Product[] Products { get; set; }
    }
}
