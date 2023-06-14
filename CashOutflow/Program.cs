using System.Text.Json.Serialization;
using CashOutflow.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// To add data to databse service
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// {
//     //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    
// }
// );

builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

builder.Services.AddDbContext<ApplicationDbContext>(); 

// Add services to the container.
builder.Services.AddControllersWithViews();
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

app.Run();


//  "DefaultConnection": "server=localhost;Database=CashOutFlow;User=sa;Password=value12345;Encrypt=false; TrustServerCertificate=True"
