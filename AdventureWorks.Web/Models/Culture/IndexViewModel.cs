using System;

namespace AdventureWorks.Web.Models.Culture
{
    public class IndexViewModel : BaseViewModel
    {
        public IndexCulture[] Cultures { get; set; }
    }

    public class IndexCulture
    {
        public string CultureID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}