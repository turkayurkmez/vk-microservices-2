using Microsoft.AspNetCore.Authentication.BearerToken;

using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));



builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();

//reverse proxy için product-api isminde bir authorization özelleştirmesi:
builder.Services.AddAuthorization(o => 
      o.AddPolicy("product-api", x => x.RequireClaim("Name"))
    );

var app = builder.Build();

//Microservice mimarisinde; login olma ve token üretme işi gateway'de olmalı.

app.MapGet("login", () =>
{
   return Results.SignIn(
             new ClaimsPrincipal(
                  new ClaimsIdentity(
                      [
                        new Claim("Name","client")
                      ], BearerTokenDefaults.AuthenticationScheme
                      )
                  ),authenticationScheme: BearerTokenDefaults.AuthenticationScheme
             );
});

app.UseAuthentication();
app.UseAuthorization();
app.MapReverseProxy();

app.Run();
