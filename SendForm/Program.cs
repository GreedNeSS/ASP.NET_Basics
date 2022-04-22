var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        string[] books = form["books"];
        string[] languages = form["languages"];
        string booksStr = string.Empty;
        string languagesStr = string.Empty;

        foreach (string book in books)
        {
            booksStr += book + " ";
        }

        foreach (string lang in languages)
        {
            languagesStr += lang + " ";
        }

        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p>" +
            $"<p>Books: {booksStr}</p><p>Languages: {languagesStr}</p></div>");
    }
    else
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/index.html");
    }
});

app.Run();
