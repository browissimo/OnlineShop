using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Enum;
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

        public ItemService(IBaseRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((Types[])Enum.GetValues(typeof(Types)))
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
                    ItemImages = item.ItemImages,
                    Colors = item.Colors,
                    VendorCode = item.VendorCode
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

        public async Task<BaseResponse<Dictionary<int, string>>> GetItem(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<int, string>>();
            try
            {
                var items = await _itemRepository.GetAll()
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
                        ItemImages = item.ItemImages,
                        Avatar = item.Avatar,
                        VendorCode = item.VendorCode
                    })
                    .Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Name);

                baseResponse.Data = items;
                return baseResponse;
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
                    ItemImages = model.ItemImages,
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

        public IBaseResponse<List<Item>> GetItems()
        {
            try
            {
                var items = _itemRepository.GetAll().ToList();
                if (!items.Any())
                {
                    return new BaseResponse<List<Item>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok
                    };
                }

                return new BaseResponse<List<Item>>()
                {
                    Data = items,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Item>>()
                {
                    Description = $"[GetItems] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
