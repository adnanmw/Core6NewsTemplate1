using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        
    }


}
