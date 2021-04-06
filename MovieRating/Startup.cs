using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieRating.Context;
using MovieRating.Repository;
using MovieRating.Repository.IRepository;
using System;

namespace MovieRating
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configure Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Movie V1",
                    Version = "v1",
                    Description = "MovieRating API",
                    Contact = new OpenApiContact
                    {
                        Name = "Ramos Masgo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });

            // Api Versioning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            // Connection database
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
            });
            
            // Add Autommaper
            services.AddAutoMapper(typeof(Startup));


            // Dependency Injecction
            services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddTransient<IMovieRepositoryAsync, MovieRepositoryAsync>();
            services.AddTransient<IActorRepositoryAsync, ActorRepositoryAsync>();
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
