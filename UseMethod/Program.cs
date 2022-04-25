var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string date = string.Empty;

app.Use(async (context, next) =>
{
    date = DateTime.Now.ToShortTimeString();

    if (context.Request.Path == "/date")
    {
        await context.Response.WriteAsync(date);
    }
    else
    {
        await next();
    }

    Console.WriteLine(date);
});

app.Run(async context => 
{
    await context.Response.WriteAsync("Hello GreedNeSS!");
});

app.Run();
