using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.ViewModels.Item
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }
        public DateTime ReliseDate { get; set; }
        public string Collection { get; set; }
        public string Type { get; set; }
    }
}
