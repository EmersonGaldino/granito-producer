using granito.application.AppService.Fees;
using granito.application.AppService.User;
using granito.application.Interface.Fees;
using granito.application.Interface.User;
using granito.bootstrapper.Configurations.Performace.Filters;
using granito.bootstrapper.Configurations.Security;
using granito.domain.Interface.Fees;
using granito.domain.Interface.User;
using granito.domain.Repositories.IRepository.Fees;
using granito.domain.Repositories.IService.User;
using granito.domain.Service.Fees;
using granito.repository.Repository.Context;
using granito.repository.Repository.Fees;
using granito.repository.Repository.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using uCondo.Galdino.Domain.Service.User;

namespace granito.bootstrapper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region .::Include injection configurations token

        var tokenConfig = new TokenConfig();
        new ConfigureFromConfigurationOptions<TokenConfig>(configuration.GetSection("TokenConfig"))
            .Configure(tokenConfig);
        services.AddSingleton(tokenConfig);

        #endregion
        
        #region .:: Configuration filter performace

        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        #endregion


        #region .::AppServices
        
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IFeesAppService, FeesAppService>();
        #endregion
        
        #region .::Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFeesService, FeesService>();
        #endregion
        
        #region .::Repositories
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IFeesRepository,FeesRepository>();
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