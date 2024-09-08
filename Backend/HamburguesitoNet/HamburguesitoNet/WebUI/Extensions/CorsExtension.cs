using Microsoft.Extensions.DependencyInjection;

namespace HamburguesitoNet.WebUI.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder
                            .WithOrigins("https://localhost:44312")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
            return services;
        }
    }
}
