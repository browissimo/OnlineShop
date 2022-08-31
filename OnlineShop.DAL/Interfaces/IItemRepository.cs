using OnlineShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Interfaces
{
    public interface IItemRepository : IBaseRepositiry<Item>
    {
        Task<Item> GetByName(string name);
    }
}
