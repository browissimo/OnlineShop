﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Enum;

namespace OnlineShop.Domain.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Color> Colors { get; set; } = new();
        public List<ItemColor> itemColors { get; set; } = new();
        public List<Size> Sizes { get; set; } = new();
        public ItemTypes ItemType { get; set; }
        public Collections Collection { get; set; }
        public int LikesCount { get; set; }
        public string VendorCode { get; set; }
        public string Avatar { get; set; }
    }
}
