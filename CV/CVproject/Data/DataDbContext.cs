using CVproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVproject.Data
{
    public class DataDbContext : IdentityDbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }
        public DbSet<MasterSocialMedia> SocialMedia { get; set; }
        public DbSet<MasterTitles> Titles { get; set; }
        public DbSet<LookuoKeywords> Keyword { get; set; }
        public DbSet<MasterAbout> About { get; set; }
        public DbSet<MasterPosition> Positions { get; set; }
        public DbSet<MasterServices> Services { get; set; }
        public DbSet<MasterTestimonials> Testimonials { get; set; }
        public DbSet<MasterClients> Clients { get; set; }
        public DbSet<MasterFacts> Facts { get; set; }
        public DbSet<MasterContact> Contact { get; set; }
        public DbSet<MasterCertificates> Certificates { get; set; }
        public DbSet<MasterEducation> Education { get; set; }
        public DbSet<MasterSkills> Skills { get; set; }
        public DbSet<MasterCategoryPortfolio> CategoryPortfolio { get; set; }
        public DbSet<MasterPortfolio> Portfolio { get; set; }
        public DbSet<MasterTransactionContentUs> TransactionContentUs { get; set; }





    }
}
