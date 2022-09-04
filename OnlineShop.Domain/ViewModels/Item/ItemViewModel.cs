using Microsoft.AspNetCore.Http;
using System;

namespace OnlineShop.Domain.ViewModels.Item
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }
        //TODO: release
        public DateTime ReliseDate { get; set; }
        public string Collection { get; set; }
        public string Type { get; set; }
        public IFormFile ItemPic { get; set; }
    }
}
