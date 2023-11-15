using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using PublicChatServer.Hubs;

namespace PublicChatServer
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddInfrastructure(builder.Configuration, builder.Environment);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //var options = new ForwardedHeadersOptions
                //{
                //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                //};

                //options.KnownNetworks.Clear();
                //options.KnownProxies.Clear();

                //builder.UseForwardedHeaders(options);
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("~/Error?statusCode={0}");

                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Registered before static files to always set header
            //app.UseXContentTypeOptions();
            //app.UseReferrerPolicy(opts => opts.NoReferrer());
            //app.UseCsp(opts => opts
            //    .BlockAllMixedContent()
            //    .ScriptSources(s => s.Self()).ScriptSources(s => s.UnsafeEval())
            //    .StyleSources(s => s.UnsafeInline())
            //);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
               .SetIsOriginAllowed(_ => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseHttpsRedirection();


            //Registered after static files, to set headers for dynamic content.
            //app.UseXfo(xfo => xfo.Deny());
            //app.UseRedirectValidation(t => t.AllowSameHostRedirectsToHttps(44348));
            //app.UseXXssProtection(options => options.EnabledWithBlockMode());
            

            app.UseRouting();
            //app.UseCors(ser.DefaultCorsPolicy);

            app.UseAuthorization();

            // Manually handle setting XSRF cookie. Needed because HttpOnly 
            // has to be set to false so that Angular is able to read/access the cookie.
            //app.Use((context, next) =>
            //{
            //    string path = context.Request.Path.Value;
            //    if (path != null && !path.ToLower().Contains("/api"))
            //    {
            //        var tokens = antiforgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN",
            //            tokens.RequestToken, new CookieOptions { HttpOnly = false }
            //        );
            //    }

            //    return next();
            //});

            //app.UseCors(options =>
            //{
            //    options//.WithOrigins("http://localhost:5500")
            //        .AllowAnyHeader()
            //        .AllowAnyOrigin()
            //        .AllowAnyHeader();
            //    //.SetIsOriginAllowed((host) => true)//.AllowAnyOrigin()
            //    //.AllowCredentials();
            //});

            //builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
            //builder =>
            //{https://localhost:7048/
            //    builder.AllowAnyMethod().AllowAnyHeader()
            //           .WithOrigins("https://localhost:44379/", "https://localhost:44560/")
            //           .AllowCredentials();
            //}));


            //var angularRoutes = new[] {
            //     "/default",
            //     "/about"
            // };
            //IAntiforgery antiforgery = null;
            //app.Use(async (context, next) =>
            //{
            //    string path = context.Request.Path.Value;
            //    if (path != null && !path.ToLower().Contains("/api"))
            //    {
            //        // XSRF-TOKEN used by angular in the $http if provided
            //        var tokens = antiforgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
            //            new CookieOptions() { HttpOnly = false });
            //    }

            //    if (context.Request.Path.HasValue && null != angularRoutes.FirstOrDefault(
            //        (ar) => context.Request.Path.Value.StartsWith(ar, StringComparison.OrdinalIgnoreCase)))
            //    {
            //        context.Request.Path = new PathString("/");
            //    }

            //    await next();
            //});

            // Manually handle setting XSRF cookie. Needed because HttpOnly has to be set to false so that
            // Angular is able to read/access the cookie.
            //app.Use((context, next) =>
            //{
            //    if (context.Request.Method == HttpMethods.Get &&
            //        (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
            //         string.Equals(context.Request.Path.Value, "/home/index", StringComparison.OrdinalIgnoreCase)))
            //    {
            //        var tokens = antiforgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN",
            //            tokens.RequestToken,
            //            new CookieOptions() { HttpOnly = false });
            //    }

            //    return next();
            //});
            //app.UseEndpoints(endpoints =>
            //{

            //    endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.MapHub<ChatHub>("/chatsocket");

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<ChatHub>("/chatsocket");     // path will look like this https://localhost:44379/chatsocket 
            //});

            app.Run();
        }
    }
}
