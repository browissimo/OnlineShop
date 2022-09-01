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

namespace OnlineShop.Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }   

        public async Task<IBaseResponse<IEnumerable<Item>>> GetAllItems()
        { 
            var baseResponse = new BaseResponse<IEnumerable<Item>>();
            try
            {
                var items = await _itemRepository.GetAllItems();

                if (1==1/*items.Count() == 0*/)
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
                    Description = $"[GetAllItems] : {ex.Message}"
                };
            }
        }
    }
}
