using Microsoft.AspNetCore.Identity;

namespace GruppKniv.Services.IdentityAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
