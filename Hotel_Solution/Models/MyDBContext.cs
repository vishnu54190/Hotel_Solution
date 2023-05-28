using Microsoft.EntityFrameworkCore;

namespace Hotel_Solution.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        public DbSet<Hotel_book> Hotel { get; set; }
        public DbSet<Room_book> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room_book>()
                .HasKey(r => new { r.RoomNo, r.Hotel_Id });

            modelBuilder.Entity<Room_book>()
                .HasOne(r => r.hotels_Boook)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.Hotel_Id);
        }
    }
}
