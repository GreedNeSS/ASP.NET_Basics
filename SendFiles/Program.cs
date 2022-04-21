var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    string path = context.Request.Path.ToString().Substring(1);
    string[] htmlFiles = Directory.GetFiles("html\\", $"{path}.????");
    string[] imgFiles = Directory.GetFiles("images\\", $"{path}.???");

    if (htmlFiles.Length > 0)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync(htmlFiles[0]);
    }
    else if (imgFiles.Length > 0)
    {
        await context.Response.SendFileAsync(imgFiles[0]);
    }
    else
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/main.html");
    }
});

app.Run();
