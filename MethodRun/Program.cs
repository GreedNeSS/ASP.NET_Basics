var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int x = 2;

//app.Run(HundleRequest);
app.Run(async (context) =>
{
    x = x * 2;
    await context.Response.WriteAsync($"Hello GreedNeSS!\nResult: {x}");
});
app.Run();

async Task HundleRequest(HttpContext context)
{
    x = x * 2;
    await context.Response.WriteAsync($"Hello GreedNeSS!\nResult: {x}");
}