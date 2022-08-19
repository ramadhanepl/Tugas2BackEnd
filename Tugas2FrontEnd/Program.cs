using Tugas2FrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "mysession.frontend";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudent, StudentServices>();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<ICourse, CourseServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
