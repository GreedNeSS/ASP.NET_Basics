using SendJSON;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;

    if (request.Path == "/api/user")
    {
        string responseText = "Некорректные данные!";

        if (request.HasJsonContentType())
        {
            Person? person = await request.ReadFromJsonAsync<Person>();

            if (person is not null)
            {
                responseText = person.ToString();
            }
        }

        await response.WriteAsJsonAsync(new {text = responseText});
    }
    else if(request.Path == "/JavaScript/JavaScript.js")
    {
        response.ContentType = "text/javascript;charset=UTF-8";
        await response.SendFileAsync("JavaScript/JavaScript.js");
    }
    else
    {
        response.ContentType = "text/html; charset:utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();
