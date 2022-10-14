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
        [Display(Name = "Coat")]
        Coat = 1,
        [Display(Name = "Denim")]
        Denim = 2,
        [Display(Name = "Dress")]
        Dress = 3,
        [Display(Name = "Jacket")]
        Jacket = 4,
        [Display(Name = "Shirt")]
        Shirt = 5,
        [Display(Name = "Short")]
        Short = 6,
        [Display(Name = "Tshirt")]
        Tshirt = 7
    }
}
