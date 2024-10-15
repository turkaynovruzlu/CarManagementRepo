using CarManagementAPİ.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarManagementAPİ.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SpeacialModel> SpeacialModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marka>().HasMany(m => m.SpeacialModels).WithOne(m => m.Marka).HasForeignKey(m => m.MarkaId);
            modelBuilder.Entity<Person>().HasOne(m => m.SpeacialModel).WithMany(m => m.Persons).HasForeignKey(m => m.SpecialModelId);
        }
    }
}
