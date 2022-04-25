var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time",
    appBuilder =>
    {
        var startTime = DateTime.Now.ToLongTimeString();
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToLongTimeString();
            Console.WriteLine($"StartTime: {startTime}");
            Console.WriteLine($"QueryTime: {time}");
            await next();
        });

        appBuilder.Run(async context =>
        {
            await context.Response.WriteAsync("Hello GreedNeSS(2)!");
        });
    });

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello GreedNeSS(1)!");
});

app.Run();
