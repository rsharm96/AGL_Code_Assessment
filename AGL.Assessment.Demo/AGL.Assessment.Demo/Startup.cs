using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Assessment.BusinessServices;
using AGL.Assessment.BusinessServices.Interfaces;
using AGL.Assessment.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace AGL.Assessment.Demo
{
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly ILogger _logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();

            //services.Add(new ServiceDescriptor(typeof(ICatListByOwnerGender), new CatListByOwnerGender()));    // singleton
            //services.Add(new ServiceDescriptor(typeof(ICatListByOwnerGender), typeof(CatListByOwnerGender), ServiceLifetime.Transient)); // Transient

            services.Add(new ServiceDescriptor(typeof(IPetListByOwnerGender), typeof(PetListByOwnerGender), ServiceLifetime.Scoped));    // Scoped
            services.AddSingleton(typeof(ILogger), _logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {          
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            loggerFactory.AddFile(Configuration.GetSection("Logging:LogFile").Value ?? "Logs/mylog-{Date}.txt");
        }
    }
}
