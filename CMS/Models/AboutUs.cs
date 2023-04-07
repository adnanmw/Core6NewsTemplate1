using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class AboutUs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(50, ErrorMessage = "The title must not exceed 50 characters.")]

        public string Title { get; set; }

        [Required(ErrorMessage = "the content cant be greater than 200 charcter .")]
        [StringLength(50, ErrorMessage = "The URL must not exceed 50 characters.")]

        public string Content { get; set; }

        [Required(ErrorMessage = "video link is required ")]
        public string VideoLink { get; set; }

    }
}
