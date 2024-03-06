using Microsoft.AspNetCore.Identity;

namespace E_Commerce.PB.IdentityServerAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
