using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MusicListBLL;
using MusicListBLL.BusinessObjects;

namespace MusicRestAPI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                var music =facade.MusicService.Add(new MusicBO()
                {
                    Name = "Copy Con - Ganja Mama",
                    Style =" Raggie"
                });
                facade.MusicService.Add(new MusicBO()
                {
                    Name = "Chrish Webby - Turn it Up",
                    Style = " Rap"
                });
                for (int i = 0; i < 1000; i++)
                {
                    facade.OrderService.Add(
                        new OrderBO()
                        {
                            DeliveryDate = DateTime.Now.AddMonths(1),
                            OrderDate = DateTime.Now.AddMonths(-1),
                            MusicId = music.Id
                        });
                }
            }

            app.UseMvc();
        }
    }
}
