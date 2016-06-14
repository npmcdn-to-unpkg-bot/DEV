using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdUserSite._00_CommonUtility.I_Contracts;
using AdUserSite._00_CommonUtility.I_Contracts.IRepo;
using AdUserSite._00_CommonUtility.I_Contracts.ISevices;
using AdUserSite._01_DataAccess;
using AdUserSite._01_DataAccess.Repo;
using AdUserSite._02_BusinessLogic.ServicesManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace AdUserSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUoW, UoW>();
            services.AddSingleton<IUserRepo, UserRepo>();
            services.AddSingleton<IUserServices, UserServices>();

            var sqlConnectionString = Configuration["DataAccessMsSqlServerProvider:ConnectionString"];
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(sqlConnectionString));

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(opt=> opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run(ctx =>
            {
                ctx.Response.Redirect("/index.html");
                return Task.FromResult(0);
            });

            app.UseMvc();
        }
    }
}
