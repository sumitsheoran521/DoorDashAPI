using DoorDashAPI.Interfaces;
using DoorDashAPI.Repositories;

namespace DoorDashAPI.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishesRepository, DishRepository>();
            services.AddScoped<ICuisinesRepository, CuisinesRepository>();
        }
    }
}
