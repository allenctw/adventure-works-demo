using System.ComponentModel;

namespace AdventureWorks.Web.Models.Product
{
    public class DetailsViewModel : BaseViewModel
    {
        public int ProductID { get; set; }
        [DisplayName("Thumbnail")]
        public string ProductThumbNailPhoto { get; set; }
        [DisplayName("Product Number")]
        public string ProductNumber { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("List Price")]
        public decimal ProductListPrice { get; set; }
    }
}