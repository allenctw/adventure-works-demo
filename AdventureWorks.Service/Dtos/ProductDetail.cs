namespace AdventureWorks.Service.Dtos
{
    public class ProductDetail
    {
        public int ProductID { get; set; }
        public byte[] ProductThumbNailPhoto { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public decimal ProductListPrice { get; set; }
    }
}
