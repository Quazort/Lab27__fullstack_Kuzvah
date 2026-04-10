var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый раз так страшно");

app.MapGet("/time", () => $"Время на сервере {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Hello {name}");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"aaaaaaaa {a + b}");



app.Run();
