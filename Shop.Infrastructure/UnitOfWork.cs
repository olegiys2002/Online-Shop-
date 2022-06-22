using Shop.Domain.IRepositories;
using Shop.Domain.IServices;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICartRepository CartRepository { get; }

        public IOrderRepository OrderRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public UnitOfWork(ApplicationDbContext applicationDbContext,IProductRepository productRepository,
                          IUserRepository userRepository,
                          ICategoryRepository categoryRepository,
                          IOrderRepository orderRepository,
                          ICartRepository cartRepository)
        {
            _applicationDbContext = applicationDbContext;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            UserRepository = userRepository;
            OrderRepository = orderRepository;
            CartRepository = cartRepository;
        }

        public async Task<int> Complete()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }


    }
}
