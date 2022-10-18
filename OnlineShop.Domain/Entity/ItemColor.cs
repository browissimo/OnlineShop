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
        public int id { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        //public int ModelSize { get; set; }

        public int SizeID { get; set; }
        public Size Size { get; set; }



        public string ModelCharacteristics { get; set; }

        public List<ColorImage> ColorImages { get; set; }
    }
}
