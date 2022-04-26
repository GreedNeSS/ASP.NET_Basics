using MiddlewareClass;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseToken("12345678");

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello GreedNeSS!");
});

app.Run();
