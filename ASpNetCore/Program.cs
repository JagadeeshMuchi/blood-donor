var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder => builder
           .WithOrigins("http://127.0.0.1:5173", "http://localhost:5173") // Vue dev server
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );
});
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();
app.UseCors("AllowVueApp");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",
     pattern: "{controller=login}/{action=SongDetails}");
});

//app.MapControllerRoute(name: "SignIn", pattern: "Sign-in", defaults: new { controller = "SignIn", action = "Index" });

app.Run();
