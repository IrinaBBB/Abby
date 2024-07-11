using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }

        [Display(Name="Display Order")]
        [Required(ErrorMessage = "Display order cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Custom error message: The value must be a valid integer.")]
        public int? DisplayOrder { get; set; }
    }
}
