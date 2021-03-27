using AssignmentsManager.Application.Entities.Assignments;
using AssignmentsManager.Application.MappingProfiles.Assignments;
using AssignmentsManager.Application.Services.Assignments;
using AssignmentsManager.Core.Entities.Assignments;
using AssignmentsManager.Infra.Database.Context;
using AssignmentsManager.Infra.Database.Repositories.Assignments;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AssignmentsManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AssignmentsManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AssignmentsManagerDatabase")));
            services.AddAutoMapper(typeof(CreateAssignmentInputModelToEntityMappingProfile));
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<AssignmentsManagerContext, AssignmentsManagerContext>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para Gerenciamento de Tarefas",
                    Description = "Gerencie seus compromissos diários através dos serviços disponibilizados por esta API..."
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignments Manager API v1");
            });
        }
    }
}
