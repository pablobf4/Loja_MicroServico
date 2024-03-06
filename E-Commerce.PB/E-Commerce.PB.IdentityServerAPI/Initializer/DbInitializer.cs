
using E_Commerce.PB.IdentityServerAPI.Configuration;
using E_Commerce.PB.IdentityServerAPI.Model;
using E_Commerce.PB.IdentityServerAPI.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.PB.IdentityServerAPI.Initializer
{
    public class DbInitializer :IDbInitializer
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;
        public  DbInitializer(Context context,
           UserManager<ApplicationUser> user,
          RoleManager<IdentityRole> role )
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            // criou as AspNetRoles  Admin e client 
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Client)).GetAwaiter().GetResult();

            // instanciou  um AspNetUsers  
            ApplicationUser adm = new ApplicationUser()
            {
                UserName = "pablo-admin",
                FirstName = "Pablo",
                Email = "pablobf4@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (21) 986993165",
                LastName = "Admin"
            };

            // criou  um AspNetUsers  passando a senha
            _user.CreateAsync(adm, "Pablo12@").GetAwaiter().GetResult();

            // relacionou a AspNetRoles  AspNetUsers
            _user.AddToRoleAsync(adm, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            // criou claim dados do admin
            var adminClaims = _user.AddClaimsAsync(adm, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,$"{adm.FirstName}{adm.LastName}"),
                new Claim(JwtClaimTypes.GivenName,$"{adm.FirstName}"),
                new Claim(JwtClaimTypes.FamilyName,$"{adm.LastName}"),
                new Claim(JwtClaimTypes.Role,IdentityConfiguration.Admin)
            }).Result;


            ApplicationUser client = new ApplicationUser()
            {
                UserName = "pablo-client",
                FirstName = "Pablo",
                Email = "pablobf4@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (21) 986993165",
                LastName = "client"
            };

            _user.CreateAsync(client, "Pablo12@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            // criou claim dados do client

            var clientinClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,$"{client.FirstName}{client.LastName}"),
                new Claim(JwtClaimTypes.GivenName,$"{client.FirstName}"),
                new Claim(JwtClaimTypes.FamilyName,$"{client.LastName}"),
                new Claim(JwtClaimTypes.Role,IdentityConfiguration.Client)
            }).Result;

        }
    }
}
