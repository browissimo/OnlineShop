using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entity
{
    public class ItemColor
    {
        public int Id { get; set; }
        [ForeignKey("VendorCode")]
        public string VendorCode { get; set; }
        public Item Item { get; set; }

        [ForeignKey("RGB")]
        public string RGB { get; set; }
        public Color Color { get; set; }

        public int ModelSize { get; set; }
        public string ModelCharacteristics { get; set; }
    }
}
