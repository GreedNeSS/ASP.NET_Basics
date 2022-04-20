using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");
//    await response.WriteAsync("Привет GreedNeSS!");
//});

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.StatusCode = 404;
//    response.ContentType = "text/plain; charset=utf-8";
//    await response.WriteAsync("Сайт не найден!");
//});

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h1>Welcome GreedNeSS</h1><h2>ASP.NET Core</h2>");
//});

dynamic person = new
{
    Name = "Ruslan",
    Age = 30
};

app.Run(async (context) =>
{
    var response = context.Response;
    response.ContentType = "application/json";
    string json = JsonSerializer.Serialize(person);
    await response.WriteAsJsonAsync(json);
});

app.Run();
