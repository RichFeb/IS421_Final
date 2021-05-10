using ActionFilters;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using NLog;
using SchoolAPI.Extensions;
using System.IO;

namespace SchoolAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepositoryManager();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options => {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.ConfigureSwagger();
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;

            }).AddXmlDataContractSerializerFormatters()
            .AddCustomCSVFormatter();

            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateOrganizationExistsAttribute>();
            services.AddScoped<ValidateUserExistsAttribute>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            services.AddAuthentication();
            IdentityModelEventSource.ShowPII = true;
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();//
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "School API v1");
            });

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}