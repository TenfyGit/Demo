using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Demo.StaticFile
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
            services.AddRazorPages();
            services.AddDirectoryBrowser();
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
                app.UseExceptionHandler("/Error");
            }
            //app.UseDefaultFiles();//要在UseStaticFiles前调用才生效，设置默认访问页面:wwwroot文件夹下的default.htm、default.html、index.htm、index.html
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("mydefault.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles(); //允许访问静态文件，默认目录为 {content root}/wwwroot
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.ContentRootPath, "MyStaticFiles")
                    ),
                RequestPath = "/StaticFiles"
            }); //提供Web根目录外的文件,注意原来的默认目录wwwroot将不再能访问
            app.UseStaticFiles(new StaticFileOptions { 
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.WebRootPath,"images")
                    ),
                RequestPath = "/MyImages"
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions { 
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.WebRootPath,"images")
                    ),
                RequestPath = "/MyImages"
            }); //目录浏览
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
