using AutoMapper;
using Data;
using Data.Repositories;
using Data.Repositories.EntityRepositories;
using Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Worldtech.Helpers.Mappers;
using Microsoft.Extensions.Configuration;


namespace Services.HelperService.Helpers
{
    public static class DependencyInjectionModule
    {        
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<OrderDetail>, OrderDetailsRepository>();
            services.AddTransient<IRepository<CurrentOrderDetail>, CurrentOrderDetailsRepository>();
            services.AddTransient<IRepository<Comment>, CommentRepository>();

            return services;
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddScoped(shoppingCart => ShoppingCartService.GetCart(shoppingCart));
            services.AddAutoMapper(typeof(OrderProfile), typeof(ProductProfile));
            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }

        public static IServiceCollection RegisterContexts(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("WorldtechConnection");
            services.AddDbContext<WorldtechDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WorldtechDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            return services;
        }        
    }
}