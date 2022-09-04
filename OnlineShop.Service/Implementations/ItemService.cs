using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Response;
using OnlineShop.Service.Interfaces;
using OnlineShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.ViewModels.Item;

namespace OnlineShop.Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IBaseResponse<ItemViewModel>> CreateItem(ItemViewModel itemViewModel)
        {
            var baseResponse = new BaseResponse<ItemViewModel>();
            try
            {
                var item = new Item()
                {
                    Name = itemViewModel.Name,
                    Description = itemViewModel.Description,
                    Price = itemViewModel.Price,
                    Collection = (Collections)Convert.ToInt32(itemViewModel.Collection),
                    Material = itemViewModel.Material,
                    ReliseDate = itemViewModel.ReliseDate,
                    Type = (Types)Convert.ToInt32(itemViewModel.Type)
                };

                await _itemRepository.Create(item);

            }
            catch (Exception ex)
            {
                return new BaseResponse<ItemViewModel>
                {
                    Description = $"[CreateItem] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Item>> GetItem(int id)
        {
            var baseResponse = new BaseResponse<Item>();
            try
            {
                var item = await _itemRepository.Get(id);
                if (item == null)
                {
                    baseResponse.Description = "Item not found";
                    baseResponse.StatusCode = StatusCode.ItemNotFound;
                    return baseResponse;
                }
                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>
                {
                    Description = $"[GetItemAsync] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Item>> GetItemByName(string name)
        {
            var baseResponse = new BaseResponse<Item>();
            try
            {
                var item = await _itemRepository.GetByName(name);
                if (item == null)
                {
                    baseResponse.Description = "Item not found";
                    baseResponse.StatusCode = StatusCode.ItemNotFound;
                    return baseResponse;
                }
                baseResponse.Data = item;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>
                {
                    Description = $"[GetItemByNameAsync] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Item>>> GetItems()
        {
            var baseResponse = new BaseResponse<IEnumerable<Item>>();
            try
            {
                var items = await _itemRepository.GetItems();

                if (items.Count() == 0)
                {
                    baseResponse.Description = "Zero items found";
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }
                baseResponse.Data = items;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Item>>
                {
                    Description = $"[GetAllItemsAsync] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteItem(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var item = await _itemRepository.Get(id);
                if (item == null)
                {
                    baseResponse.Description = "Item not found";
                    baseResponse.StatusCode = StatusCode.ItemNotFound;
                    return baseResponse;
                }

                await _itemRepository.Delete(item);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[DeleteItem] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model)
        {
            var baseresponse = new BaseResponse<Item>();
            try
            {
                var item = await _itemRepository.Get(id);
                if (item == null)
                {
                    baseresponse.StatusCode = StatusCode.ItemNotFound;
                    baseresponse.Description = "Item not found";
                    return baseresponse;
                }

                item.Name = model.Name;
                item.Description = model.Description;
                item.Collection = (Collections)Convert.ToInt32( model.Collection);
                item.Material = model.Material;
                item.Price = model.Price;
                item.ReliseDate = model.ReliseDate;
                item.Type = (Types)Convert.ToInt32(model.Type);

                await _itemRepository.Update(item);

                return baseresponse;

            }
            catch (Exception ex )
            {

                return new BaseResponse<Item>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
    }
}
