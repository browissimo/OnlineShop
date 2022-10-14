using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShop.Domain.Enum
{
    public enum ItemTypes
    {
        [Display(Name = "Jacket")]
        Jacket = 1,
        [Display(Name = "Coat")]
        Coat = 2,
        [Display(Name = "Denim")]
        Denim = 3,
        [Display(Name = "Dress")]
        Dress = 4,
        [Display(Name = "Short")]
        Short = 5,
        [Display(Name = "Shirt")]
        Shirt = 6,
        [Display(Name = "Tshirt")]
        Tshirt = 7
    }
}
