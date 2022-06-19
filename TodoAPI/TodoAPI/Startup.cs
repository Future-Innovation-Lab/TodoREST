using BankingApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Services;

namespace TodoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TodoConnectionString")));
            services.AddControllers();
            services.AddTransient<DbInitialiser>();
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TodoContext todoContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // For mobile apps, allow http traffic.
                app.UseHttpsRedirection();
            }

            //   todoContext.Seed();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}

