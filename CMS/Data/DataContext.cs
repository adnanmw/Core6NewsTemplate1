using Microsoft.EntityFrameworkCore;
using CMS.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Add your DbSet properties here
        public DbSet<Logo> Logos { get; set; }

        public DbSet<SliderImage> SliderImages { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Blogger> Blogs { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrganizationStatistics> Statistics { get; set; }

        public DbSet<Member> members { get; set; }

        public DbSet<Footer> Footer { get; set; }

        public DbSet<SocialMediaLinks> SocialMediaLinks { get; set;}

    }
}
