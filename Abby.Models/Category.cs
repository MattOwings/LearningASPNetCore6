using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage="Display Order must be between 1 and 100")] // min and max range of display order
        public int DisplayOrder { get; set; }
    }
}
