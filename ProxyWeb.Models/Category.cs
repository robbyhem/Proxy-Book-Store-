using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProxyWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(20), DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(1,99, ErrorMessage = "Input a number from 1 - 99"), DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
