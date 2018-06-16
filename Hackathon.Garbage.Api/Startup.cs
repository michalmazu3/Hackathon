using AutoMapper;
using Hackathon.Garbage.Dal.Hubs;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Hackathon.Garbage.Dal
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

            services.AddDbContext<FloraDbContext>(options =>
                          //options.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = D:\\dev\\hackathon\\Database\\FloraDb.mdf;Integrated Security=True")
                          options.UseSqlServer(Configuration.GetConnectionString("FreeMsDb"))
                          );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;

            services.AddCors(options => options.AddPolicy("CorsPolicy",
           builder =>
           {
               builder
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowAnyOrigin()
                  .AllowCredentials();
           }));

            services.AddSignalR();
            services.AddAutoMapper();

            services.AddScoped<IFieldsRepository, FieldsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IExecutiveRepository, ExecutiveRepository>();
            services.AddScoped<IAlertsRepository, AlertsRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.UseSignalR(
                routes =>
            {
                routes.MapHub<MessageHub>("/PhotoNotification");
            }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
