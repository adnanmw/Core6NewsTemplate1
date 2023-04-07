using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class SocialMediaLinks
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Facebook link is required.")]
        [MaxLength(255, ErrorMessage = "The Facebook link cannot exceed 255 characters.")]
        public string FacebookLink { get; set; }

        [Required(ErrorMessage = "The Twitter link is required.")]
        [MaxLength(255, ErrorMessage = "The Twitter link cannot exceed 255 characters.")]
        public string TwitterLink { get; set; }

        [Required(ErrorMessage = "The Google link is required.")]
        [MaxLength(255, ErrorMessage = "The Google link cannot exceed 255 characters.")]
        public string GoogleLink { get; set; }

        [Required(ErrorMessage = "The Instagram link is required.")]
        [MaxLength(255, ErrorMessage = "The Instagram link cannot exceed 255 characters.")]
        public string InstagramLink { get; set; }
    }
}
