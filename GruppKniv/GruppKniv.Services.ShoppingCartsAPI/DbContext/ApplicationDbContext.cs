using GruppKniv.Services.ShoppingCartsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GruppKniv.Services.ShoppingCartsAPI.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<CartDetails> CartDetails { get; set; }
    public DbSet<Product> Products { get; set; }
}
