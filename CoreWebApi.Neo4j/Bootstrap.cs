using System.Diagnostics;

namespace CoreWebApi.Neo4j
{
    public static class Bootstrap
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<Neo4jDriver>((services) =>
            {
                var _configuration = services.GetRequiredService<IConfiguration>();
                return new Neo4jDriver(
                                    _configuration["Neo4j:URI"],
                                    _configuration["Neo4j:Username"],
                                    _configuration["Neo4j:Password"]);
            });
            return services;
        }

    }
}
