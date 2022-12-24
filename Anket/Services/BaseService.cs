using Anket.Interface;
using BasePersonDBService.Interfaces;
using BasePersonDBService.Services;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Services;

namespace Anket.Services
{
    public static class BaseService
    {
        public static void AddDBService(this IServiceCollection services)
        {
            services.AddScoped<IDSUActiveData, DSUActiveData>();
            services.AddScoped<IBasePersonActiveData, BasePersonActiveData>();
            services.AddScoped<IApplicationDBActiveData, ApplicationDBActiveData>();

        }
    }
}