using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class SliderImage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The title  must not exceed 100 characters.")]

        public string FileName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The title  must not exceed 100 characters.")]

        public string ContentType { get; set; }

        [Required]
        public byte[] Data { get; set; }
        [StringLength(150, ErrorMessage = " must not exceed 100 characters.")]

        public string Header { get; set; }
        [StringLength(350, ErrorMessage = " must not exceed 100 characters.")]

        public string Paragraph { get; set; }

    }
}
