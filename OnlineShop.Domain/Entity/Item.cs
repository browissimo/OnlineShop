using System;
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
        public Collections Collection { get; set; }
        public string VendorCode { get; set; }
        public byte[] Avatar { get; set; }
    }
}
