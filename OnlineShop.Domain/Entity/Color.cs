using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }
        public List<Item> Items { get; set; } = new();
    }
}
