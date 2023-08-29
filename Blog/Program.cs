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

app.Run();
