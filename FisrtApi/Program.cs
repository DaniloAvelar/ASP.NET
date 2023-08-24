var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>{
    return Results.Ok("Olá Mundo");
});

app.MapGet("/welcome/{nome}", (string nome) => {
    return Results.Ok($"Bem vindo {nome} a sua primeira api!");
});

app.MapPost("/", (User user) => {
    return Results.Ok(user);
});

app.Run();

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
}
