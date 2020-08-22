namespace AdventureWorks.Web.Models
{
    public class BaseViewModel
    {
        public BaseCulture[] Cultures { get; set; }
    }

    public class BaseCulture
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}