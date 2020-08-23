using System;

namespace AdventureWorks.Web.Models.Culture
{
    public class DetailsViewModel : BaseViewModel
    {
        public string CultureID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}