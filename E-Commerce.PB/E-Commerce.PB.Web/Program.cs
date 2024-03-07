
using E_Commerce.PB.Web.Services;
using E_Commerce.PB.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProdutoService, ProdutoService>(c =>
c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));

builder.Services.AddHttpClient<ICarrinhoService, CarrinhoService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CartAPI"]));

builder.Services.AddHttpClient<ICuponService, CuponService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CouponAPI"]));


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "geek_shopping";
        options.ClientSecret = "my_super_secret";
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.NameClaimType = "role";
        options.Scope.Add("geek_shopping");
        options.SaveTokens = true;
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
