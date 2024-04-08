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
        public DbSet<Products> Products { get; set; }
        public DbSet<Product_Categories> Product_Categories { get; set; }

        [DbFunction(Schema = "dbo")]
        public static int fn_ProductCategory_count(int pCategoryId)
        {
            throw new Exception();
        }
    }
}
