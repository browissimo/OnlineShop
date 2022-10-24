using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Response;
using OnlineShop.Domain.ViewModels.Item;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IItemService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();
        IBaseResponse<List<ItemViewModel>> GetItems();
        Task<IBaseResponse<ItemViewModel>> GetItem(int id);
        Task<IBaseResponse<List<ItemViewModel>>> GetItemsByType(string type);
        Task<IBaseResponse<List<ItemViewModel>>> Search(string searchString);
        Task<IBaseResponse<Item>> Create(ItemViewModel Item);
        Task<IBaseResponse<bool>> Delete(int id);
        Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model);
        

    }
}
