using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Adder
{
    public class Startup
    {
        private int x = 0;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/add", AddX);
            app.Map("/minus", MinusX);
            app.Map("/plus", Plus);

            app.Run(async context => { await context.Response.WriteAsync($"{x}"); });
        }

        private void AddX(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                x++;
                await context.Response.WriteAsync($"{x}");
            });
        }
        
        private void MinusX(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                x--;
                await context.Response.WriteAsync($"{x}");
            });
        }
        
        private void Plus(IApplicationBuilder app)
        {
            app.UseKeyChecker();
            app.Run(async context =>
            {
                x += int.Parse(context.Request.Query["y"]);    
                await context.Response.WriteAsync($"{x}");
            });
        }
    }
}