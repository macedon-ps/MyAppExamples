using BlazorHttpClientApp;
using BlazorHttpClientApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();  // добавляем фабрику HttpClient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

/* Пример 1. HtppClient 
// на запрос по пути "/time" возвращаем время
app.MapGet("/time", () => DateTime.Now.ToLongTimeString());
*/

/* Пример 2. Отправка данных через HtppClient. Метод POST */
app.MapPost("/user", (Person user) =>
{
    // если длина имени меньше 3 или больше 20 символов
    if (user.Name.Length < 3 || user.Name.Length > 20)
        return Results.BadRequest(new { details = "Имя должно иметь не меньше 3 и не больше 20 символов" });
    // если возраст меньше 1 или больше 110
    if (user.Age < 1 || user.Age > 110)
        return Results.BadRequest(new { details = "Некорректный возраст" });
    // если все нормально, устанавливаем id для нового пользователя
    user.Id = Guid.NewGuid().ToString();
    // посылаем объект в виде json
    return Results.Json(user);
});


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
