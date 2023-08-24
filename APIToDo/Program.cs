using APITODO.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Adicionando a instancia dos Controllers
builder.Services.AddDbContext<AppDbContext>(); // Passando o DbContext como um serviço, podendo ser usado como um serviço (asp.net cria e destroi) sem using

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
