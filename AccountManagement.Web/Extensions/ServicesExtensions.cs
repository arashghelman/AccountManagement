using AccountManagement.Application.Contracts.Interfaces;
using AccountManagement.Application.Services;
using AccountManagement.Infrastructure.Configurations;
using AccountManagement.Infrastructure.Data;
using AccountManagement.Infrastructure.Repositories;

namespace AccountManagement.Web.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>(_ =>
            {
                var configurations = configuration.GetSection("MongoDbConfigurations").Get<MongoDbConfigurations>();

                return new MongoDbContext(configurations);
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();
        }
    }
}
