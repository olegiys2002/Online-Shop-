using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Domain.Models.Cart;
using Shop.Domain.Models.Orders;
using Shop.Domain.Models.ProductModels;
using Shop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedRolesToUsers(builder);
            SeedDefaultCategories(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser identityUser = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "oa6092698@gmail.com",
                NormalizedUserName = "Admin"

            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            string adminPassword = _configuration["adminPassword"];
            string hash = passwordHasher.HashPassword(identityUser, adminPassword);
            identityUser.PasswordHash = hash;
            builder.Entity<ApplicationUser>().HasData(identityUser);

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
           new IdentityRole()
           {
               Id = "fab4fac1-c546-41de-aebc-a14da6895711",
               Name = "admin",
               ConcurrencyStamp = "1",
               NormalizedName = "admin"
           },
           new IdentityRole()
           {
               Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
               Name = "customer",
               ConcurrencyStamp = "2",
               NormalizedName = "customer"
           }
           );
        }

        private void SeedRolesToUsers(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }
                );
        }

        private void SeedDefaultCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(

                new Category()
                {
                    Id = 1,
                    Name = "Наушники"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Стиральные машины"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Холодильники"
                },
                new Category() 
                { 
                    Id=4,
                    Name="Кондиционеры"
                },
                new Category() 
                { 
                    Id=5,
                    Name="Тостеры"
                },
                new Category() 
                {
                    Id=6,
                    Name="Кофемашины"  
                },
                new Category()
                {
                    Id = 7,
                    Name = "Пылесосы"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Мультиварки"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Телевизоры"
                },
                new Category()
                {
                    Id = 10,
                    Name = "Блендеры"
                },
                new Category()
                {
                     Id = 11,
                     Name = "Мясорубки"
                },
                new Category()
                {
                     Id = 12,
                     Name = "Соковыжималки"
                }


                ); 
        }

    }
}
