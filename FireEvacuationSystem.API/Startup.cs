﻿using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;


namespace FireEvacuationSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment=env;
        }

        public IConfiguration Configuration { get; }

        public static IHostingEnvironment HostingEnvironment {get;set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings.DbConnectionString = Configuration.GetValue<string>("AppSettings:DbConnectionString"); 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

          services.AddSwaggerGen(c =>
        {
            //The generated Swagger JSON file will have these properties.
            c.SwaggerDoc("v1", new Info
            {
                Title = "Fire Evacuation System Api",
                Version = "v1",
            });
            
            //Locate the XML file being generated by ASP.NET...
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            
            //... and tell Swagger to use those XML comments.
            c.IncludeXmlComments(xmlPath);
        });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
           app.UseSwagger();
        
        //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger- Fire Evacuation System Api");
        });
        }
    }
}
