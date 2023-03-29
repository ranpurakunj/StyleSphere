using Microsoft.Extensions.DependencyInjection;
using StyleSphere.Services;

namespace StyleSphere
{
    public class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IOrderDatumService, OrderDatumService>();
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}
