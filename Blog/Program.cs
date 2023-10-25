<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
=======
using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        //Desabilitando a checagem automatica do ModelState pelo .NET
        options.SuppressModelStateInvalidFilter = true; 
    });

builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapControllers();
>>>>>>> d0b3793719c3dee71a2387b0a161fe768cc71c57

app.Run();
