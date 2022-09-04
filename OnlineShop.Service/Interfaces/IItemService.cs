using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Response;
using OnlineShop.Domain.ViewModels.Item;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IItemService
    {
        Task<IBaseResponse<ItemViewModel>> CreateItem(ItemViewModel itemViewModel);
        Task<IBaseResponse<Item>> GetItem(int id);
        Task<IBaseResponse<Item>> GetItemByName(string name);
        Task<IBaseResponse<IEnumerable<Item>>> GetItems();
        Task<IBaseResponse<bool>> DeleteItem(int id);
        Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model);

    }
}
