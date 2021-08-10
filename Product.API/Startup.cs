using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Product.API.AutoMapper;
using Product.API.Helpers;
using Product.Domain.Interfaces;
using Product.Infrastructure.Data;
using Product.Infrastructure.Services;

namespace Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string CorsPolice = "AllowOrigin";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy(CorsPolice, options => options.AllowAnyOrigin()));

            services.AddDbContext<ProductDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ProductConnection"),
                    x => x.UseNetTopologySuite()));

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddHttpClient("brand", c =>
            {
                c.BaseAddress = new Uri(Configuration["BrandAPIUri"]);
                // c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                //     "Basic",
                //     Convert.ToBase64String(
                //         System.Text.Encoding.ASCII.GetBytes(
                //             "http:http"
                //         )
                //     )
                // );
                //TODO:Remove this
            }).ConfigureHttpMessageHandlerBuilder(builder =>
            {
                builder.PrimaryHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
                };
            });
            
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();  
            services.AddTransient<IBrandClient, BrandClient>();  
            services.AddTransient<IProductService, ProductService>();  
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Product.API",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product.API v1"));
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}