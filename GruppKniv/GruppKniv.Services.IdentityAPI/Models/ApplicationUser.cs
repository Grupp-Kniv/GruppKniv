using Microsoft.AspNetCore.Identity;

namespace GruppKniv.Services.IdentityAPI.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
