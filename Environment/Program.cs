var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Environment.EnvironmentName = "Test";
//app.Environment.EnvironmentName = "Staging";
//app.Environment.EnvironmentName = "Production";

if (app.Environment.IsEnvironment("Test"))
{
    app.Run(async context => await context.Response.WriteAsync("In Test!"));
}
else if (app.Environment.IsStaging())
{
    app.Run(async context => await context.Response.WriteAsync("In Staging!"));
}
else if (app.Environment.IsProduction())
{
    app.Run(async context => await context.Response.WriteAsync("In Production!"));
}
else
{
    app.Run(async context => await context.Response.WriteAsync("In Development!"));
}

app.Run();
