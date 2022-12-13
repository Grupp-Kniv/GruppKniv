using System.Security.Claims;
using GruppKniv.Services.Identity.DbContexts;
using GruppKniv.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GruppKniv.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(StaticDetails.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Customer)).GetAwaiter().GetResult();

            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin123@gmail.com",
                Email = "admin123@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "123121231",
                FirstName = "Pizza", 
                LastName ="Admin"
            };
            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, StaticDetails.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.FirstName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Admin),

            }).Result;
            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer123@gmail.com",
                Email = "customer123@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "123121231",
                FirstName = "Pizza",
                LastName = "Customer"
            };
            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, StaticDetails.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName + " " + customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.FirstName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Customer),

            }).Result;
        }
    }
}
