using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add authentication services
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    // Other authentication configurations...
})
.AddCookie("Cookies", options =>
{
    // Cookie options configuration...
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Include authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
app.Run("http://0.0.0.0:80");