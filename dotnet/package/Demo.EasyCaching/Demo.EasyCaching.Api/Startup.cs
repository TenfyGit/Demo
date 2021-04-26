using Autofac;
using Demo.EasyCaching.IService;
using Demo.EasyCaching.Service;
using EasyCaching.Core;
using EasyCaching.Interceptor.Castle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.EasyCaching.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEasyCaching(options =>
            {
                options.UseInMemory();
            });
            services.AddControllers();
            // for Castle  
            services.ConfigureCastleInterceptor(options => options.CacheProviderName = EasyCachingConstValue.DefaultInMemoryName);
        }
        // for castle
        public void ConfigureContainer(ContainerBuilder builder)
        {
            
            builder.RegisterModule(new AutofacSetup());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
