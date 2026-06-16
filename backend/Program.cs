var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.MapGet("/", () => "Hello World!");

app.MapGet("/tips", (decimal totalTips, int employees) =>
{
    if (employees <= 0)
        return Results.BadRequest("Количество сотрудников должно быть больше 0");

    return Results.Ok(totalTips / employees);
});

app.Run();