﻿using GruppKniv.Services.OrdersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GruppKniv.Services.OrdersAPI.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }


    public DbSet<Order?> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

}