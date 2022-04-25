var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/time", Time);
app.Map("/home", appBuilder =>
{
    appBuilder.Map("/index", Index);
    appBuilder.Map("/about", About);
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("Home Page");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Page not found");
});

app.Run();

void Time(IApplicationBuilder appBuilder)
{
    string time = DateTime.Now.ToLongTimeString();

    appBuilder.Use(async (context, next) =>
    {
        Console.WriteLine($"Time: {time}");
        await next();
    });

    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync($"Time: {time}");
    });
}

void Index(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("Index Page");
    });
}

void About(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("About Page");
    });
}