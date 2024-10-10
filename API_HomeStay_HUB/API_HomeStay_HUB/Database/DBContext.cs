using Microsoft.EntityFrameworkCore;
using API_HomeStay_HUB.Model; // Đảm bảo bạn đã import model Administrator

namespace API_HomeStay_HUB.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingProcess> BookingProcesses { get; set; }
        public DbSet<CategoryArticle> CategoryArticles { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<HomeStay> HomeStays { get; set; }
        public DbSet<PartnershipReg> PartnershipRegs { get; set; }
        public DbSet<DetailHomeStay> DetailHomeStays { get; set; }
        public DbSet<HomeStayAmenities> HomeStayAmenities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OwnerStay> OwnerStays { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ReviewAndRating> ReviewAndRatings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleID);

            modelBuilder.Entity<User>()
                .HasKey(r => r.UserID);

            modelBuilder.Entity<HomeStay>()
           .Property(h => h.HomestayID)
           .ValueGeneratedOnAdd();


            modelBuilder.Entity<HomeStayAmenities>()
               .HasKey(h => new { h.AmenityID, h.HomestayID });

            modelBuilder.Entity<Customer>()
            .HasOne(c => c.User)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.UserID);

            modelBuilder.Entity<OwnerStay>()
                .HasOne(o => o.User)
                .WithOne(u => u.OwnerStay)
                .HasForeignKey<OwnerStay>(o => o.UserID);

            modelBuilder.Entity<Administrator>()
                .HasOne(a => a.User)
                .WithOne(u => u.Administrator)
            .HasForeignKey<Administrator>(a => a.UserID);


        }

    }
}
