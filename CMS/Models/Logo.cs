using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    // named logo in case there is more than 1 logo in the project every logo will be changed to this 
    public class Logo
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "The file name  name  must not exceed 50 characters.")]

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}
