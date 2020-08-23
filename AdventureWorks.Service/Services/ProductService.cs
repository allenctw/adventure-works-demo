using AdventureWorks.Dal;
using AdventureWorks.Service.Dtos;
using AdventureWorks.Service.Interfaces;
using System;
using System.Linq;

namespace AdventureWorks.Service.Services
{
    public class ProductService : IProductService
    {
        private AdventureWorksEntities context;
        private IDbRepository<vProductAndDescription> vProductAndDescRepo;
        private IDbRepository<Dal.Product> productRepo;
        private IDbRepository<ProductProductPhoto> productProductPhotoRepo;
        private IDbRepository<ProductPhoto> productPhotoRepo;

        public ProductService()
        {
            context = new AdventureWorksEntities();
            vProductAndDescRepo = new DbRepository<vProductAndDescription>(context);
            productRepo = new DbRepository<Dal.Product>(context);
            productProductPhotoRepo = new DbRepository<ProductProductPhoto>(context);
            productPhotoRepo = new DbRepository<ProductPhoto>(context);
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

        public ProductDetail GetProductDetail(int id)
        {
            try
            {
                var productDetail = productRepo.GetAll()
                .Join(
                    productProductPhotoRepo.GetAll(),
                    pr => pr.ProductID,
                    pppr => pppr.ProductID,
                    (pr, pppr) => new { pr, pppr })
                .Join(
                    productPhotoRepo.GetAll(),
                    t1 => t1.pppr.ProductPhotoID,
                    ppr => ppr.ProductPhotoID,
                    (t1, ppr) => new { t1, ppr })
                .Where(t2 => t2.t1.pr.ProductID == id && t2.t1.pppr.Primary == true)
                .Select(t2 => new ProductDetail
                {
                    ProductID = t2.t1.pr.ProductID,
                    ProductNumber = t2.t1.pr.ProductNumber,
                    ProductName = t2.t1.pr.Name,
                    ProductListPrice = t2.t1.pr.ListPrice,
                    ProductThumbNailPhoto = t2.ppr.ThumbNailPhoto
                })
                .FirstOrDefault();
                return productDetail;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
