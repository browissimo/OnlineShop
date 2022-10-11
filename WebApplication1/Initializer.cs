using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.Repositories;
using OnlineShop.Domain.Entity;
using OnlineShop.Service.Implementations;
using OnlineShop.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace OnlineShop
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Item>, ItemRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            services.AddScoped<IBaseRepository<Color>, ColorRepository> ();
            services.AddScoped<IBaseRepository<ItemColor>, ItemColorRepository>();

        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}