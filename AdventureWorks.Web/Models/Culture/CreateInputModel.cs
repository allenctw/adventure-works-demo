using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Web.Models.Culture
{
    public class CreateInputModel
    {
        [Required]
        [MaxLength(6)]
        public string CultureID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}