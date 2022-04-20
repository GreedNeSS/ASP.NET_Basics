var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    string response = "<table><tr><td>Заголовок</td><td>Значение</td></tr>";

    foreach (var header in context.Request.Headers)
    {
        response += $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>";
    }

    response += "</table>";
    response += $"<h2>Path: {context.Request.Path}</h2>";

    response += context.Request.Path.ToString() switch
    {

        "/date" => $"<h3>Date: {DateTime.Now.ToShortDateString()}</h3>",
        "/time" => $"<h3>Time: {DateTime.Now.ToShortTimeString()}</h3>",
        _ => "<h3>Default response!</h3>",
    };

    response += @"<h3>Параметры строки запроса</h3><table><tr><td>Параметр</td><td>Значение</td></tr>";

    foreach (var param in context.Request.Query)
    {
        response += $"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>";
    }

    response += "</table>";
    await context.Response.WriteAsync(response);
});

app.Run();
