using DiscountManagement.Configuration;
using ShopManagement.Infrastructure.Configuration;
using InventoryManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Add services to the container.
var connectionstrin = builder.Configuration.GetConnectionString("ProjectYasDB");
ShopManagementBootstrapper.Configure(builder.Services, connectionstrin);
DiscountManagementBootstrapper.Configure(builder.Services, connectionstrin);
InventoryManagementBootstrapper.Configure(builder.Services, connectionstrin);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS Value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
