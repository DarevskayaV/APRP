var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapPost("/api/form", async (HttpContext context) =>
{
    var data = await context.Request.ReadFromJsonAsync<FormData>();

    if (data == null)
        return Results.BadRequest("Ошибка данных");

    var line = $"{data.FirstName} {data.LastName}{Environment.NewLine}";
    await File.AppendAllTextAsync("data.txt", line);

    return Results.Ok("Данные успешно сохранены");
});

app.Run("http://0.0.0.0:5106");

record FormData(string FirstName, string LastName);
