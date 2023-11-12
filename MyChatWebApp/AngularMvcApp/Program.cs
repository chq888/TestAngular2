var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyHeader();
    //.SetIsOriginAllowed((host) => true)//.AllowAnyOrigin()
    //.AllowCredentials();
});

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
