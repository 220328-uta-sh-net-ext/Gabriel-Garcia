using Microsoft.EntityFrameworkCore;
using Models;
namespace DL
{
    public class PlantsDbContext:DbContext
    {
        public PlantsDbContext():base()
        {  }
        public PlantsDbContext(DbContextOptions options):base(options)
        {  }
        public DbSet<Plants> Plants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plants>().Property(p => p.PlantsId).HasColumnName("Id").ValueGeneratedOnAdd();
            //modelBuilder.Entity<Plants>().HasData(new Plants() { PlantsName="",PlantsType=""});
        }
    }
}
