using Microsoft.Extensions.DependencyInjection;
using Shop.Core.IRepositories;
using Shop.Core.IServices;
using Shop.Core.Services;
using Shop.Domain.Models.User;
using Shop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Shop.Infrastructure.IoC
{
    public class DependencyInjection
    {
        public static void RegisterServices (IServiceCollection services)
        {
           
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
       
        }
    }
}
