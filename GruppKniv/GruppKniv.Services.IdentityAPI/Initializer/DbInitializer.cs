

using GruppKniv.Services.IdentityAPI.DbContext;
using GruppKniv.Services.IdentityAPI.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GruppKniv.Services.IdentityAPI.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(StaticDetatiles.Admin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(StaticDetatiles.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(StaticDetatiles.Customer)).GetAwaiter().GetResult();
        }
        else { return; }


        //Create an admin with its claims
        ApplicationUser adminUser = new ApplicationUser()
        {
            UserName = "admin1@gmail.com",
            Email = "admin1@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            Name = "Ben Admin",
        };

        _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, StaticDetatiles.Admin).GetAwaiter().GetResult();

        var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
            new Claim(JwtClaimTypes.Name,adminUser.Name),
            new Claim(JwtClaimTypes.Role,StaticDetatiles.Admin),
        }).Result;


        //Create a user with its claims
        ApplicationUser customerUser = new ApplicationUser()
        {
            UserName = "customer1@gmail.com",
            Email = "customer1@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            Name = "Ben Customer",
        };

        _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(customerUser, StaticDetatiles.Customer).GetAwaiter().GetResult();

        var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
            new Claim(JwtClaimTypes.Name,customerUser.Name),
            new Claim(JwtClaimTypes.Role,StaticDetatiles.Customer),
        }).Result;
    }
}
