namespace PatientsApplicationMicroservice
{

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using PatientsApplicationMicroservice.Web.Application.Queries;
    using PatientsApplicationMicroservice.Web.Application.DataServiceClients;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientApplicationMicroservice.Web", Version = "v1" });
            });
            services.AddHttpClient();
            services.AddTransient<IPatientsApplicationMicroserviceQueryHandler, PatientsApplicationMicroserviceQueryHandler>();
            services.AddTransient<IPatientsDatabaseClient, PatientsDatabaseClient>();
            services.AddTransient<IAvailabilityDatabaseClient, AvailabilityDatabaseClient>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientApplicationMicroservice.Web v1"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
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
