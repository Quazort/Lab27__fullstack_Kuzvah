using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Добро пожаловать на сервер!");

app.MapGet("/about", () => "Это мой первый раз так страшно");

app.MapGet("/time", () => $"Время на сервере {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"Hello {name}");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"aaaaaaaa {a + b}");

app.MapGet("/student", () => new
{
    Name = "Иванов",
    Group = "ISP-233",
    FirstWeekOfYear = 3,
    IsActive = true
});

app.MapGet("/subjects", () => new[]
{
    "РПМ",
    "РМП",
    "ИСРПО",
    "СП",
});

app.MapGet("/product/{id}", (int id) => new Product(
    Id: id,

Name: $"Товар №{id}",
Price: id * 99.99m,
Instock: id % 2 == 0)
);

app.Use(async (context, next) => {
    Console.WriteLine($"[LOG] {context.Request.Method}{context.Request.Path}");
    await next(context);
    Console.WriteLine($"[LOG] ОТвет отправлен: {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Powered-By", "aspnet core lab27");
    await next(context);
});

// app.Use(async (context, next) =>
// {
//     var key = context.Request.Query["key"];
//     if(key != "bublik")
//     {
//         context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//         return "Error";
//     }
    
// });


app.Run();
record Product(int Id, string Name, decimal Price, bool Instock);