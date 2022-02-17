using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Orderly.Core.Domain.Common;
using Orderly.Core.EntityModels;
using Orderly.Factories.Analyzer;
using Orderly.Factories.Calendar;
using Orderly.Factories.Contact;
using Orderly.Factories.Distributor;
using Orderly.Factories.Investment;
using Orderly.Factories.Monitor;
using Orderly.Factories.Portfolio;
using Orderly.Factories.Token;
using Orderly.Helpers;
using Orderly.Models.Enums;
using Orderly.Repositories;
using Orderly.Scheduler;
using Orderly.Services.Comman;
using Orderly.Services.Contact;
using Orderly.Services.Email;
using Orderly.Services.Investment;
using Orderly.Services.Logg;
using Orderly.Services.Monitor;
using Orderly.Services.Notification;
using Orderly.Services.Portfolio;
using Orderly.Services.Token;
using Orderly.Services.User;
using Orderly.Services.Dashboard;
using Quartz;
using System.Collections.Generic;
using static Orderly.Helpers.Common;
using Orderly.Factories.Dashboard;
using Microsoft.AspNetCore.Mvc.Razor;
using Orderly.Services.OverTheCounter;
using Orderly.Factories.OverTheCounter;
using Microsoft.AspNetCore.HttpOverrides;

namespace Orderly
{
    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                       .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            LinkExpiryTime = Configuration.GetSection("LinkExpiryTime").Get<string>();
            EncryptionKey = Configuration.GetSection("EncryptionKey").Get<string>();
            SystemEmail = Configuration.GetSection("systemEmail").Get<string>();
            SystemPassword = Configuration.GetSection("systemPassword").Get<string>();
            Common.Host = Configuration.GetSection("host").Get<string>();
            Port = Configuration.GetSection("port").Get<string>();
            MonitorCronExpression = Configuration.GetSection("MonitorScheduler").Get<string>();
            IsTGEMonitorNeedToRun = Configuration.GetSection("IsTGEMonitorNeedToRun").Get<bool>();
            IsOTCNeedToArchive = Configuration.GetSection("IsOTCNeedToArchive").Get<bool>();
            OTCArchiveInHours = System.Convert.ToInt32(Configuration.GetSection("OTCArchiveInHours").Get<int>());
            Environment = Configuration.GetSection("environment").Get<string>();
            string connectionString = string.Empty;
            if(Environment == EnvironmentType.Local.ToString())
            {
                WebsiteUrl = Configuration.GetSection("localUrl").Get<string>();
                connectionString = Configuration.GetConnectionString("LocalConnection");
            }
            if (Environment == EnvironmentType.Prod.ToString())
            {
                WebsiteUrl = Configuration.GetSection("productionUrl").Get<string>();
                connectionString = Configuration.GetConnectionString("ProdConnection");
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //repositories
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

            //Factories
            services.AddScoped<IPortfolioModelFactory, PortfolioModelFactory>();
            services.AddScoped<IInvestmentModelFactory, InvestmentModelFactory>();
            services.AddScoped<IContactModelFactory, ContactModelFactory>();
            services.AddScoped<IDistributorModelFactory, DistributorModelFactory>();
            services.AddScoped<IAnalyzerModelFactory, AnalyzerModelFactory>();
            services.AddScoped<ITokenModelFactory, TokenModelFactory>();
            services.AddScoped<IMonitoringModelFactory, MonitoringModelFactory>();
            services.AddScoped<ICalendarModelFactory, CalendarModelFactory>();
            services.AddScoped<IDashboardModelFactory, DashboardModelFactory>();
            services.AddScoped<IOTCModelFactory, OTCModelFactory>();
            services.AddSingleton<IRazorViewEngine, RazorViewEngine>();

            //Services
            services.AddScoped<IPortfolioMonitoringService, PortfolioMonitoringService>();
            services.AddScoped<IInvestmentService, InvestmentService>();
            services.AddScoped<ICommanService, CommanService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<INetworkTokenService, NetworkTokenService>();
            services.AddScoped<IMonitoringService, MonitoringService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IQueuedEmailService, QueuedEmailService>();
            services.AddScoped<ILoggService, LoggService>();
            services.AddScoped<IApplicationUser, AppUser>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IOTCService, OTCService>();
            services.AddSingleton(_config);
            services.AddSingleton<EthService>();
            services.AddSingleton<BitService>();
            services.AddSingleton<ServiceResolver<IPortfolioService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "1":
                        return serviceProvider.GetService<EthService>();
                    case "2":
                        return serviceProvider.GetService<BitService>();
                    default:
                        throw new KeyNotFoundException(); // or maybe return null, up to you
                }
            });
             
            services.AddQuartz(q =>
            {
                // base quartz scheduler, job and trigger configuration
                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                // Create a "key" for the job
                var jobKey = new JobKey("MonitorScheduler");

                // Register the job with the DI container
                q.AddJob<MonitorScheduler>(opts => opts.WithIdentity(jobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                    .ForJob(jobKey) // link to the MonitorScheduler
                    .WithIdentity("MonitorScheduler-trigger") // give the trigger a unique name
                    .WithCronSchedule(Common.MonitorCronExpression)); // run every 15 minutes

            });

            services.AddQuartzHostedService(
                   q => q.WaitForJobsToComplete = true);

            // ASP.NET Core hosting
            services.AddQuartzServer(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.RegisterRoutes();


        }
    }
}
