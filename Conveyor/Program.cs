using Conveyor;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenMiddleware>("4444");
app.UseMiddleware<RoutingMiddleware>();

app.Run();
