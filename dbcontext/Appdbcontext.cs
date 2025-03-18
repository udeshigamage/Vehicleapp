using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.dbcontext

{
    public class Appdbcontext: DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {
        }
       public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne<Manufacture>(s => s.Manufacture)
                .WithMany(g => g.Vehicles)
                .HasForeignKey(s => s.ManufactureId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
