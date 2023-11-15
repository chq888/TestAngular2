using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.VisualBasic;
using System;

namespace PublicChatUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services
                .AddInfrastructure(builder.Configuration, builder.Environment);

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //                .AddJwtBearer(options =>
            //                {
            //                    // base-address of your identity server
            //                    options.Authority = Configuration["Auth:Authority"];
            //                    // name of the API resource
            //                    options.TokenValidationParameters = new TokenValidationParameters
            //                    {
            //                        ValidateIssuer = true,
            //                        ValidAudiences = Configuration.GetSection("Auth:Audiences").Get<List<string>>(),
            //                    };
            //                });

            // In production, the Angular files will be served from this directory
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/aspnetcorespa";
            });

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors((corsPolicyBuilder) =>
            {
                corsPolicyBuilder.AllowAnyOrigin();
                corsPolicyBuilder.AllowAnyMethod();
                corsPolicyBuilder.AllowAnyHeader();
                // Uncomment if you have any custom headers you need to expose
                // corsPolicyBuilder.WithExposedHeaders("X-InlineCount");
            });

            //app.UseCors(ServicesExtensions.DefaultCorsPolicy);
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //                       name: "default",
            //                       pattern: "{controller}/{action=Index}/{id?}");
            //    endpoints.MapRazorPages();

            //    //endpoints.MapHub<Chat>("/chathub");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    endpoints.MapControllerRoute(
            //         name: "default",
            //         pattern: "{controller}/{action}/{id?}");

            //    // Handle redirecting client-side routes to Index route
            //    endpoints.MapFallbackToController("Index", "Home");
            //});

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                //if (app.Environment.IsDevelopment())
                //{
                //    //spa.UseAngularCliServer(npmScript: "start");
                //    //   OR
                //    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                //}
            });

            //app.UseCors(builder => builder
            //   .SetIsOriginAllowed(_ => true)
            //   .AllowAnyMethod()
            //   .AllowAnyHeader()
            //   .AllowCredentials());

            app.MapControllers();

            app.MapFallbackToController("Index", "Home");
            app.MapFallbackToFile("/index.html");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}