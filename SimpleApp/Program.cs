using SimpleApp;
using System.Text.RegularExpressions;

List<Person> people = new List<Person>
{
    new Person { Id = Guid.NewGuid().ToString(), Name = "GreedNeSS", Age = 30},
    new Person { Id = Guid.NewGuid().ToString(), Name = "Marcus", Age = 45},
    new Person { Id = Guid.NewGuid().ToString(), Name = "Henry", Age = 22},
};

CRUD_API crud = new CRUD_API(people);

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

    if (path == "/api/users" && request.Method == "GET")
    {
        await crud.GetAllPeopleAsync(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await crud.GetPersonAsync(id, response, request);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await crud.CreatePersonAsync(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await crud.UpdatePersonAsync(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await crud.DeletePersonAsync(id, response, request);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();
