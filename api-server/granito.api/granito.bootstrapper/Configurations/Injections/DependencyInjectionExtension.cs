using granito.application.AppService.User;
using granito.application.Interface.User;
using granito.bootstrapper.Configurations.Performace.Filters;
using granito.domain.Interface.User;
using granito.domain.Repositories.IService.User;
using granito.repository.Repository.Context;
using granito.repository.Repository.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uCondo.Galdino.Domain.Service.User;

namespace granito.bootstrapper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        #region .:: Configuration filter performace

        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        #endregion


        #region .::AppServices
        
        services.AddScoped<IUserAppService, UserAppService>();
        #endregion
        
        #region .::Services
        services.AddScoped<IUserService, UserService>();
        #endregion
        
        #region .::Repositories
        services.AddScoped<IUserRepository,UserRepository>();
        #endregion
        
        #region .::UnitOfWork
        
        services.AddScoped<ContextDb>();
        #endregion


        return services;
    }  
    
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var getEnv = Environment.GetEnvironmentVariable("ENVIRONMENT"); // Caso queira utilizar varialve de ambiente

        if (getEnv is "Development" or null)
        {
            services.AddDbContext<ContextDb>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
        }
        else
        {

            services.AddDbContext<ContextDb>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection")!));
        }

    }
    
}