using IdentityServerCenter.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerCenter
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
            #region 客户端模式
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential() //添加临时证书，开发时用
            //    .AddInMemoryApiResources(ClientCredentialConfig.GetApiResources())
            //    .AddInMemoryClients(ClientCredentialConfig.GetClients())
            //    .AddInMemoryApiScopes(ClientCredentialConfig.GetApiScopes());
            #endregion
            #region 密码认证模式
            services.AddIdentityServer()
                .AddDeveloperSigningCredential() //添加临时证书，开发时用
                .AddInMemoryApiResources(PwdCredentialConfig.GetApiResources())
                .AddInMemoryClients(PwdCredentialConfig.GetClients())
                .AddTestUsers(PwdCredentialConfig.GetTestUsers())
                .AddInMemoryApiScopes(PwdCredentialConfig.GetApiScopes());
            #endregion
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
