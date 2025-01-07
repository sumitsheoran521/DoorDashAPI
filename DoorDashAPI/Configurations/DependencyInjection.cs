using DoorDashAPI.Interfaces;
using DoorDashAPI.Repositories;
using DoorDashAPI.Services;

namespace DoorDashAPI.Configurations
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IRestaurantRepository, RestaurantService>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            //services.AddScoped<IDishesRepository, DishService>();
            services.AddScoped<IDishesRepository, DishRepository>();
        }
    }
}
