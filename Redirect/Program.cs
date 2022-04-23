var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    if (context.Request.Path == "/old")
    {
        //context.Response.Redirect("/new");
        context.Response.Redirect("/new", true);
    }
    else if(context.Request.Path == "/new")
    {
        await context.Response.WriteAsync("New Page");
    }
    else
    {
        await context.Response.WriteAsync("Main Page");
    }
});

app.Run();
