using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Response;
using OnlineShop.Domain.ViewModels.Item;
using OnlineShop.Domain.ViewModels.Page;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IItemService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();
        IBaseResponse<List<ItemViewModel>> GetItems();
        IBaseResponse<ItemPagesViewModel> GetItems(int page);
        Task<IBaseResponse<ItemViewModel>> GetItem(int id);
        Task<IBaseResponse<List<ItemViewModel>>> GetItemsByType(string type);
        Task<IBaseResponse<List<ItemViewModel>>> Search(string searchString);
        Task<IBaseResponse<ItemViewModel>> ChangeColor(int id, int colorId);
        Task<IBaseResponse<Item>> Create(ItemViewModel Item);
        Task<IBaseResponse<bool>> Delete(int id);
        Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model);
        

    }
}
