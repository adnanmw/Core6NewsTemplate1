namespace CMS.Models.Viewmodel
{
    public class HomeViewModel
    {
        public IEnumerable<SliderImage> SliderImages { get; set; }
        public AboutUs AboutUs { get; set; }

        public IEnumerable<Blogger> Bloggers { get; set; }
        public OrganizationStatistics OrganizationStatistics { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public IEnumerable<Member> members { get; set; }

        public IEnumerable<Category> categories { get; set; }

        public Footer Footer { get; set; }

        public List<Logo> Logos { get; set; }

        public List<SocialMediaLinks> SocialMediaLinks { get; set; }


    }
}
