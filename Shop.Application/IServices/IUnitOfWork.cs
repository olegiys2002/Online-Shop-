using Shop.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.IServices
{
    public interface IUnitOfWork
    {
         ICartRepository CartRepository { get; }
         IProductRepository ProductRepository { get; }
         IUserRepository UserRepository { get; }
         ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task<int> Complete();
    }
}
