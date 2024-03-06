using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = "https://localhost:4435/";
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateAudience = false
                  };
              });

builder.Services.AddOcelot();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseOcelot();

app.Run();


