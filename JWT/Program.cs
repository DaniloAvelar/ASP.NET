using JWT.Services;
using JWT.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JWT;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();


// Sempre adicionar esse Midware para trabalhar com autenticação
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

//Sempre utilizar o Authorization depois do Authentication
builder.Services.AddAuthorization();


var app = builder.Build();

//Sempre adicionar esse Midware (Antes das Rotas) para trabalhar com autenticação
app.UseAuthentication();

//Sempre utilizar nessa ordem
app.UseAuthorization();

app.MapGet("/", (TokenService service)
    =>
    {
        var user = new User(
            1,                             // ID
            "Danilo-Avelar",               // Name
            "xyz@dan.com",                 // Email
            "123!@#",                      // Password
            "https://www",                 // Image
            new[] { "student", "premium" }   // Roles
        );

        return service.Create(user);
    }
);

app.Run();
