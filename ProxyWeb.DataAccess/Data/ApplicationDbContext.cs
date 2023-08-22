using Microsoft.EntityFrameworkCore;
using ProxyWeb.Models;

namespace ProxyWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
               new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero",
                    ISBN = "SW999999001",
                    PriceList = 99,
                    Price = 90,
                    Price50= 85,
                    Price100= 80,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                
                new Product
                {
                    Id = 2,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero",
                    ISBN = "WS33333301",
                    PriceList = 40,
                    Price = 30,
                    Price50= 25,
                    Price100= 20,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                
                new Product
                {
                    Id = 3,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero",
                    ISBN = "CAW777777701",
                    PriceList = 30,
                    Price = 30,
                    Price50= 30,
                    Price100= 30,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                
                new Product
                {
                    Id = 4,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero",
                    ISBN = "RIT055555501",
                    PriceList = 55,
                    Price = 50,
                    Price50= 40,
                    Price100= 35,
                    CategoryId = 2,
                    ImageUrl = ""

                }
                );
        }
    }
}
