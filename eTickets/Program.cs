using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DBDesignMasterclassConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext configuration
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

//Services configuration
builder.Services.AddScoped<IActorsService, ActorService>();
builder.Services.AddScoped<IProducersService, ProducersService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppDBInitializer.Seed(app);

app.Run();
