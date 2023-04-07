using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Footer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100, ErrorMessage = "The title  must not exceed 100 characters.")]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(350, ErrorMessage = "The description  must not exceed 350 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100, ErrorMessage = "The title  must not exceed 100 characters.")]
        public string LocationAddress { get; set; }
    }
}
