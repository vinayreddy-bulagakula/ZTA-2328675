using ZTAWebApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddSession();


builder.Services.AddSingleton<UserService>();
builder.Services.AddHttpClient();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession(); // Session must be before endpoint routing


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
