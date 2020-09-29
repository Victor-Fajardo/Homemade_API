using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Homemade.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Homemade.Domain.Services;
using Homemade.Persistence.Repositories;
using Homemade.Persistence;
using Homemade.Service;

namespace Homemade
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
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Homemade-api-in-memory");
                //options.UseMySQL(Configuration.GetConnectionString("MySQLConnection"));
            });

            //Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IUserChefRepository, UserChefRepository>();
            services.AddScoped<IUserCommonRepository, UserCommonRepository>();
            services.AddScoped<ICommonChefRepository, CommonChefRepository>();

            services.AddRouting(options => options.LowercaseUrls = true);


            // Services
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IUserChefService, UserChefService>();
            services.AddScoped<IUserCommonService, UserCommonService>();
            services.AddScoped<ICommonChefService, CommonChefService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomSwagger();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCustomSwagger();
        }
    }
}

