using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IItemService
    { 
        Task<IBaseResponse<IEnumerable<Item>>> GetAllItems();
    }
}
