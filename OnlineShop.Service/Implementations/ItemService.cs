using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Enum;
using OnlineShop.Domain.Extensions;
using OnlineShop.Domain.Response;
using OnlineShop.Domain.ViewModels.Item;
using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<ItemColor> _itemColorRepository;

        public ItemService(IBaseRepository<Item> itemRepository, IBaseRepository<ItemColor> itemColorRepository)
        {
            _itemRepository = itemRepository;
            _itemColorRepository = itemColorRepository;

        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((ItemTypes[])Enum.GetValues(typeof(ItemTypes)))
                    .ToDictionary(k => (int)k, t => t.ToString());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ItemViewModel>> GetItem(int id)
        {
            try
            {
                var item = await _itemRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                var ItemColors = await _itemColorRepository.GetAll().FirstOrDefaultAsync(x => x.ItemID == id);
                if (item == null)
                {
                    return new BaseResponse<ItemViewModel>()
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ItemNotFound
                    };
                }

                var data = new ItemViewModel()
                {
                    Id = item.Id,
                    ReleaseDate = item.ReleaseDate.ToLongDateString(),
                    Description = item.Description,
                    Name = item.Name,
                    Price = item.Price,
                    Material = item.Material,
                    Collection = item.Collection.ToString(),
                    Avatar = item.Avatar,
                    Colors = item.Colors,
                    VendorCode = item.VendorCode,
                    Sizes = item.Sizes,
                    ColorImages = ItemColors.ColorImages,
                    ModelCharacteristics = ItemColors.ModelCharacteristics,
                    ModelSize = ItemColors.ModelSize
                };

                return new BaseResponse<ItemViewModel>()
                {
                    StatusCode = StatusCode.Ok,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ItemViewModel>()
                {
                    Description = $"[GetItem] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<List<ItemViewModel>>> GetItemsByType(string type)
        {
            var baseResponse = new BaseResponse<List<ItemViewModel>>();
            try
            {
                var items =  _itemRepository.GetAll()
                    .Select(item => new ItemViewModel()
                    {
                        Id = item.Id,
                        ReleaseDate = item.ReleaseDate.ToLongDateString(),
                        Description = item.Description,
                        Name = item.Name,
                        Price = item.Price,
                        Material = item.Material,
                        Collection = item.Collection.ToString(),
                        Colors = item.Colors.ToList(),
                        //ItemImages = item.ItemImages,
                        ItemType = item.ItemType.GetDisplayName(),
                        Avatar = item.Avatar,
                        VendorCode = item.VendorCode
                    })
                   .ToList().Where(x=>x.ItemType.Equals(type)).ToList();

                baseResponse.Data = items;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ItemViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Item>> Create(ItemViewModel model)
        {
            try
            {
                var item = new Item()
                {
                    Id = model.Id,
                    ReleaseDate = DateTime.Now,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price,
                    Material = model.Material,
                    Collection = (Collections)Convert.ToInt32(model.Collection),
                    Colors = model.Colors.ToList(),
                    //ItemImages = model.ItemImages,
                    Avatar = model.Avatar,
                    VendorCode = model.VendorCode
                };
                await _itemRepository.Create(item);

                return new BaseResponse<Item>()
                {
                    StatusCode = StatusCode.Ok,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                var item = await _itemRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                /*await _carRepository.Delete(car);*/

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model)
        {
            try
            {
                var item = await _itemRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return new BaseResponse<Item>()
                    {
                        Description = "Item not found",
                        StatusCode = StatusCode.ItemNotFound
                    };
                }

                item.Description = model.Description;
                item.Collection = (Collections)Convert.ToInt32(model.Collection);
                item.Price = model.Price;
                item.Material = model.Material;
                item.ReleaseDate = DateTime.ParseExact(model.ReleaseDate, "yyyyMMdd HH:mm", null);
                item.Name = model.Name;

                await _itemRepository.Update(item);


                return new BaseResponse<Item>()
                {
                    Data = item,
                    StatusCode = StatusCode.Ok,
                };
                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<ItemViewModel>> GetItems()
        {
            try
            {
                var items = _itemRepository.GetAll()
                    .Select(item => new ItemViewModel()
                    {
                        Id = item.Id,
                        ReleaseDate = item.ReleaseDate.ToLongDateString(),
                        Description = item.Description,
                        Name = item.Name,
                        Price = item.Price,
                        Material = item.Material,
                        Collection = item.Collection.ToString(),
                        Colors = item.Colors.ToList(),
                        //ItemImages = item.ItemImages,
                        ItemType = item.ItemType.GetDisplayName(),
                        Avatar = item.Avatar,
                        VendorCode = item.VendorCode
                    }).ToList();

                if (!items.Any())
                {
                    return new BaseResponse<List<ItemViewModel>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok
                    };
                }

                return new BaseResponse<List<ItemViewModel>>()
                {
                    Data = items,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ItemViewModel>>()
                {
                    Description = $"[GetItems] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
