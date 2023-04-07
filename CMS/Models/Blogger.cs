using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Blogger
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100, ErrorMessage = "The title  must not exceed 100 characters.")]

        public string Title { get; set; }
        [StringLength(900, ErrorMessage = "The description must not exceed 900 characters.")]
        [Required(ErrorMessage = "Description is required ")]

        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "The author name  must not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter author name .")]

        public string Author { get; set; }

        public int? CategoryId { get; set; } // make the property nullable
        [StringLength(70, ErrorMessage = "The category length  must not exceed 70 characters.")]

        public Category Category { get; set; } // add navigation property


        public string ImageUrl { get; set; } // Add this property to store the URL of the image



    }
}