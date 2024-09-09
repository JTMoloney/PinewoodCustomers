using PinewoodCustomers.BusinessServices.Interfaces;
using PinewoodCustomers.BusinessServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Handle Dependency Injection
ConfigureServices(builder.Services);

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


void ConfigureServices(IServiceCollection services)
{
    // Register Services for Dependency Injection
    services.AddScoped<IApiCallingService, ApiCallingService>();
    services.AddScoped<ICustomerService, CustomerService>();

    // Add HttpClient for use in the services
    services.AddHttpClient();

    // Add controllers and views
    services.AddControllersWithViews();
}