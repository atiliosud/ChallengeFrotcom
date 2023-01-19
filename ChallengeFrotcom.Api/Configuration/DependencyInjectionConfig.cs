using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Service;
using ChallengeFrotcom.Infra.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ChallengeFrotcom.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IImagesCategoriesRepository, ImagesCategoriesRepository>();            

            services.AddScoped<INotification, NotificationService>();
            services.AddScoped<ICategorieService, CategorieService>();
            services.AddScoped<IImagemService, ImagemService>();
            services.AddScoped<IImagesCategoriesService, ImagesCategoriesService>();

            return services;
        }
    }
}
