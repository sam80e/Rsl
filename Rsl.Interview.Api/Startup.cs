using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Rsl.Interview.Api.Repository;
using Rsl.Interview.Api.Repository.Interfaces;
using Rsl.Interview.Api.Services;
using Rsl.Interview.Api.Services.Interfaces;

namespace Rsl.Interview.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<InterviewContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));                        
            services.AddScoped<IWordService, WordService>(); 
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddSwaggerGen((options) => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Rsl.Interview.Api", Version = "v1" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rsl.Interview.Api");
            });

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
        }
    }
}
