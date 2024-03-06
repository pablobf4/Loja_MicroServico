
using Duende.IdentityServer.Services;
using E_Commerce.PB.IdentityServerAPI.Configuration;
using E_Commerce.PB.IdentityServerAPI.Initializer;
using E_Commerce.PB.IdentityServerAPI.Model;
using E_Commerce.PB.IdentityServerAPI.Model.Context;
using E_Commerce.PB.IdentityServerAPI.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.IdentityServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Context>(o => o.UseSqlServer("IdentityDatabase"));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            // definir as configurações de segurança da aplicação 
            builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

            }).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
              .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
              .AddInMemoryClients(IdentityConfiguration.Clients)
              .AddAspNetIdentity<ApplicationUser>()
              .AddDeveloperSigningCredential();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                // use dbInitializer
                dbInitializer.Initialize();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();


            // use dbInitializer
            //     dbInitializer.Initialize();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
