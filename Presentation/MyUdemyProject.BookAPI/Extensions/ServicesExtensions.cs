using MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers;
using MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers;
using MyUdemyProject.Application.Features.CQRS.Handler.BrandHandlers;
using MyUdemyProject.Application.Features.CQRS.Handler.CarHandlers;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Persistence.ApplicationDbContext;
using MyUdemyProject.Persistence.Data;

namespace MyUdemyProject.BookAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
        public static void AddAboutCqrs(this IServiceCollection services)
        {
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<AddAboutQueryHandler>();
            services.AddScoped<RemoveAboutQueryHandler>();
            services.AddScoped<UpdateAboutQueryHandler>();
        }
        public static void AddDbContext(this IServiceCollection services) {
            services.AddScoped<CarBookDbContext>();
        }
        public static void AddBannerCqrs(this IServiceCollection services)
        {
            services.AddScoped<GetBannerFromIdHandler>();
            services.AddScoped<GetAllBannerHandler>();
            services.AddScoped<CreateBannerHandler>();
            services.AddScoped<UpdateBannerHandler>();
            services.AddScoped<RemoveBannerHandler>();
        }
        public static void AddBrandCqrs(this IServiceCollection services) {
            services.AddScoped<AddBrandHandler>();
            services.AddScoped<GetAllBrandHandlers>();
            services.AddScoped<GetBrandWithIdHandler>();
            services.AddScoped<RemoveBrandHandlers>();
            services.AddScoped<UpdateBrandHandler>();
        }
        public static void AddCarsCqrs(this IServiceCollection services) {
            services.AddScoped<AddCarHandlers>();
            services.AddScoped<UpdateCarHandlers>();
            services.AddScoped<RemoveCarHandlers>();
            services.AddScoped<GetAllCarsHandlers>();
            services.AddScoped<GetCarsWithIdHandler>();
        }
    }
}
