using AdventureWorks.Service.Dtos;

namespace AdventureWorks.Service.Interfaces
{
    public interface IProductService
    {
        ProductCatalog[] GetProductCatalog(string cultureID);
        ProductDetail GetProductDetail(int id);
    }
}
