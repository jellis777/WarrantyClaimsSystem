using Microsoft.EntityFrameworkCore;
using Warranty.Application.Interfaces;
using Warranty.Application.Services;
using Warranty.Infrastructure.Persistence;
using Warranty.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Tell the system where the database lives
builder.Services.AddDbContext<WarrantyDbContext>(options =>
    options.UseSqlite("Data Source=warranty.db"));

// 2. Tell the system how to get a ClaimRepository
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();

// 3. Tell the system how to get SubmitClaimService
builder.Services.AddScoped<SubmitClaimService>();

// 4. Enable controllers
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WarrantyDbContext>();
    db.Database.EnsureCreated();
}

// 5. Map controllers to routes
app.MapControllers();

// 6. Run the app
app.Run();


