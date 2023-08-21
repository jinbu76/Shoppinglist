using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shoppinglist.Domains.Supermarket.Domain;
using Shoppinglist.Domains.Supermarket.Repository;
using Shoppinglist.Domains.Supermarket.Repository.Repositories;
using Shoppinglist.Domains.Supermarket.ServiceDefinition;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Shoppinglist.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        // JWT

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(ConfigureSwagger);

        // Service Definition
        services.AddScoped<ISupermarketService, SupermarketService>();

        // Repositories
        services.AddScoped<ISupermarketRepository, SupermarketRepository>();

        //DbContext
        var connectionString = Configuration.GetConnectionString("SqlServer");
        services.AddDbContext<SupermarketDBContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("SqlServer"))
        );

        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseCors(cors => { cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
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