using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder//.WithOrigins("http://localhost:5500")
//                                .AllowAnyMethod()
//                                .AllowAnyHeader()
//                                .SetIsOriginAllowed(origin => true)//.AllowAnyOrigin() // allow any origin
//                                .AllowCredentials();
//        });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options//.WithOrigins("http://localhost:5500")
    .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyHeader();
    //.SetIsOriginAllowed((host) => true)//.AllowAnyOrigin()
    //.AllowCredentials();
});

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();
