using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MessagePack;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

namespace PublicChatServer
{
    public static class ServicesExtensions
    {
        public static string DefaultCorsPolicy = nameof(DefaultCorsPolicy);

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            });

            services.AddHttpContextAccessor()
                .AddResponseCompression()
                .AddMemoryCache()
                .AddHealthChecks();

            // Shared configuration across apps
            services.AddCustomConfiguration(configuration)
                .AddCustomSignalR()
                .AddCustomCors(configuration)
                .AddCustomLocalization(configuration, environment)
                .AddCustomUi(environment);

            services.AddAntiforgery(options => {
                options.HeaderName = "X-XSRF-TOKEN";
            });

            return services;
        }

        private static IServiceCollection AddCustomLocalization(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-GB"),
                        new CultureInfo("en-US"),
                        new CultureInfo("fr-FR")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-GB", uiCulture: "en-GB");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                });

            return services;
        }

        private static IServiceCollection AddCustomUi(this IServiceCollection services, IWebHostEnvironment environment)
        {
            var controllerWithViews = services.AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
;
            var razorPages = services.AddRazorPages()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization();

            if (environment.IsDevelopment())
            {
                controllerWithViews.AddRazorRuntimeCompilation();
                razorPages.AddRazorRuntimeCompilation();
            }

            return services;
        }
        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, new()
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var config = new TConfig();

            configuration.Bind(config);

            services.AddSingleton(config);

            return config;
        }

        private static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Custom configuration
            //services.ConfigurePoco<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

            return services;
        }
        private static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(ServicesExtensions.DefaultCorsPolicy,
            //        builder =>
            //        {
            //            var corsList = configuration.GetSection("CorsOrigins").Get<List<string>>()?.ToArray() ?? new string[] { };
            //            builder.WithOrigins(corsList)
            //                .AllowAnyMethod()
            //                .AllowAnyHeader();
            //        });
            //});



            //services.AddCors(o => o.AddPolicy("AllowAllPolicy", options =>
            //{
            //    options.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .WithExposedHeaders("X-InlineCount");
            //}));

            //services.AddCors(o => o.AddPolicy("AllowSpecific", options =>
            //        options.WithOrigins("http://localhost:4200")
            //               .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
            //               .WithHeaders("accept", "content-type", "origin", "X-InlineCount")
            //               .WithExposedHeaders("X-InlineCount")));

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //                          .AllowAnyMethod()
            //                          .AllowAnyHeader());
            //});

            return services;
        }

        private static IServiceCollection AddCustomSignalR(this IServiceCollection services)
        {
            services.AddSignalR()
                .AddMessagePackProtocol(options => options.SerializerOptions = MessagePackSerializerOptions.Standard.WithSecurity(MessagePackSecurity.UntrustedData))
                .AddJsonProtocol();

            return services;
        }

        private static X509Certificate2 GetCertificate(IWebHostEnvironment environment, IConfiguration configuration)
        {
            var useDevCertificate = bool.Parse(configuration["UseDevCertificate"]);

            var cert = new X509Certificate2(Path.Combine(environment.ContentRootPath, "sts_dev_cert.pfx"), "1234");

            if (environment.IsProduction() && !useDevCertificate)
            {
                if (Convert.ToBoolean(configuration["UseLocalCertStore"]))
                {
                    using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    var certificateThumbprint = configuration["CertificateThumbprint"];

                    store.Open(OpenFlags.ReadOnly);
                    var certs = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false);
                    cert = certs[0];
                    store.Close();
                }
                //else
                //{
                //    // Azure deployment, will be used if deployed to Azure
                //    var vaultConfigSection = configuration.GetSection("Vault");
                //    var keyVaultService = new KeyVaultCertificateService(vaultConfigSection["Url"], vaultConfigSection["ClientId"], vaultConfigSection["ClientSecret"]);
                //    cert = keyVaultService.GetCertificateFromKeyVault(vaultConfigSection["CertificateName"]);
                //}
            }

            return cert;
        }

    }
}
