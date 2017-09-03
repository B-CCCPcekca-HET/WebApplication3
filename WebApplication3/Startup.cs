using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WebApplication3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public Startup(IHostingEnvironment env)//config
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddJsonFile(path: "Config/config.json");
            // создаем конфигурацию
            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; } // свойство конфинурации


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env )
        {
           // app.UseDefaultFiles();//указать дефолтной  страницу index  или default
            app.UseStaticFiles();//можно юзать хтмл

           

            app.Run(async (context) =>
            {
                var color = AppConfiguration["color"];
                var text = AppConfiguration["text"];

                await context.Response.WriteAsync($"Hello World!<br/>{color}{text} ");
            });
        }

      
    }
}
