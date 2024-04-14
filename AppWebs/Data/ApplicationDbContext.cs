using AppWebs.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Product_Categories> Product_Categories { get; set; }
        public DbSet<Inventories> Inventories { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
        public DbSet<Employees> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventories>().HasNoKey();
        }

        [DbFunction(Schema = "dbo")]
        public static int fn_ProductCategory_count(int pCategoryId)
        {
            throw new Exception();
        }
    }
}
