using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquors.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Liquors
{
    public class Startup
    {
        protected IConfigurationRoot ConfigurationRoot;

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddXmlFile("Config.xml");
            ConfigurationRoot = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<LiquorsContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(
                    ConfigurationRoot["DbConnectionString"]));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async context => await context.Response.WriteAsync("Hello World!"));
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
