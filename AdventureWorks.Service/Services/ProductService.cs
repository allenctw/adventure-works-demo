using AdventureWorks.Dal;
using AdventureWorks.Service.Dtos;
using AdventureWorks.Service.Interfaces;
using System;
using System.Linq;

namespace AdventureWorks.Service.Services
{
    public class ProductService : IProductService
    {
        private IDbRepository<vProductAndDescription> vProductAndDescRepo;

        public ProductService()
        {
            vProductAndDescRepo = new DbRepository<vProductAndDescription>();
        }

        public ProductCatalog[] GetProductCatalog(string cultureID)
        {
            try
            {
                var products = vProductAndDescRepo.Get(pad => pad.CultureID == cultureID);
                var catalog = products.GroupBy(p => new { p.ProductModel, p.Description })
                    .AsEnumerable()
                    .Select(p => new ProductCatalog
                    {
                        ModelName = p.Key.ProductModel,
                        ModelDesc = p.Key.Description,
                        Products = p.Select(x => new Dtos.Product 
                        { 
                            ID = x.ProductID, 
                            Name = x.Name 
                        }).ToArray()
                    }).ToArray();
                return catalog;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
