using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set; }
    }
}
