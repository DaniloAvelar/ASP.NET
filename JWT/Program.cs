using JWT.Services;
using JWT.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapGet("/", (TokenService service) 
    =>
    {
        var user = new User(
            1,                             // ID
            "Danilo-Avelar",               // Name
            "xyz@dan.com",                 // Email
            "123!@#",                      // Password
            "https://www",                 // Image
            new[] {"student", "premium"}   // Roles
        );

        return service.Create(user);
    } 
);

app.Run();
