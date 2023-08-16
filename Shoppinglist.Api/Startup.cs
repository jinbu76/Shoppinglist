using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Shoppinglist.Api;

public partial class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // JWT

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(ConfigureSwagger);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        //app.UseAuthorization();


        //app.MapControllers();
        //app.UseCors();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void ConfigureSwagger(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Shoppinglist API",
            Description = "APIs for supermarket, article and price management",
            Contact = new OpenApiContact
            {
                Name = "Mike Gründer",
                Email = "mike@gruender.dev"
            }
        });
    }
}