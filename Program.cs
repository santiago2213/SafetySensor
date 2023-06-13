using LibraryGroup7;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcGroup7.Data;
using MvcGroup7.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRecordedDataRepo, RecordedDataRepo>();
builder.Services.AddTransient<IFacilityRepo, FacilityRepo>();
builder.Services.AddTransient<ISensorRepairRequestRepo, SensorRepairRequestRepo>();
builder.Services.AddTransient<IAppUserRepo, AppUserRepo>();

var app = builder.Build();

using( var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        InitialDatabase.SeedDatabase(services);
    }
    catch(Exception serviceException)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(serviceException, "Error while using db, user or role service");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
