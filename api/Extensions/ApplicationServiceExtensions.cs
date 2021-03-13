using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {  
            services.AddScoped<Interfaces.ITokenService, Services.TokenService>();
            
            services.AddDbContext<Data.DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            });

            return services;

        }
    }
}