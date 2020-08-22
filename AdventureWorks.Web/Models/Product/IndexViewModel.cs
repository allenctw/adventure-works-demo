using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Web.Models.Product
{
    public class IndexViewModel : BaseViewModel
    {
        public IndexProductCatalog[] Catalogs { get; set; }
    }

    public class IndexProductCatalog
    {
        public string ModelName { get; set; }
        public string ModelDesc { get; set; }
        public IndexProduct[] Products { get; set; }
    }

    public class IndexProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}