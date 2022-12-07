using GruppKniv.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace GruppKniv.Services.ProductsAPI.DbContexts
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<Product> Products { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);


                modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 1,
                    Name = "Vesuvio",
                    Price = 85,
                    Ingridients = "Ost, Skinka, Tomatsås Gluten",
                    ImageUrl = "https://gruppkniv.blob.core.windows.net/gruppkniv/pizza-vesuvio.jpeg",
                   
                });
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 2,
                    Name = "Kebab Pizza",
                    Price = 100,
                    Ingridients = "Ost, Kebab, Tomat, Färsk Sallad, Kebabsås, Gluten",
                    ImageUrl = "https://gruppkniv.blob.core.windows.net/gruppkniv/stellas-kebabpizza.png.jpg",
                   
                });
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 3,
                    Name = "Calzone",
                    Price = 95,
                    Ingridients = "Ost, Skinka, Tomatsås, Gluten",
                    ImageUrl = "https://gruppkniv.blob.core.windows.net/gruppkniv/calzone.jpg",
                    
                });
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 4,
                    Name = "Hawaii",
                    Price = 85,
                    Ingridients = "Ost, Skinka, Ananas,Tomatsås, Gluten",
                    ImageUrl = "https://gruppkniv.blob.core.windows.net/gruppkniv/hawaiian-pizza-recipe-605894-2.jpg",
                   
                });
            }

        }
    }

