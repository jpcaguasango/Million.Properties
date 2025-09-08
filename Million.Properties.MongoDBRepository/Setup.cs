using Microsoft.Extensions.DependencyInjection;
using Million.Properties.Domain.Ports;

namespace Million.Properties.MongoDBRepository
{
    public static class Setup
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
                sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<IDbRepository, MongoDbRepository>();

            return services;
        }
    }
}
