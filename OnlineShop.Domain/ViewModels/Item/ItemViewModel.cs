using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using OnlineShop.Domain.Entity;
using OnlineShop.Domain.Enum;

namespace OnlineShop.Domain.ViewModels.Item
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input name")]
        [MaxLength(20, ErrorMessage = "Name should be equal 20 or less than 20")]
        [MinLength(5, ErrorMessage = "Name should be 5 or more than 5")]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Material { get; set; }

        [Required(ErrorMessage = "Input price")]
        public double Price { get; set; }
        public List<Color> Colors { get; set; }
        public List<ColorImage> ColorImages { get; set; }

        public List<Size> Sizes { get; set; }
        public string ModelCharacteristics { get; set;}
        public int ModelSize { get; set; }
        public string ReleaseDate { get; set; }
        public string Collection { get; set; }
        public string ItemType { get; set; }
        public string VendorCode { get; set; }
        public string Avatar { get; set; }
        public byte[] Image { get; set; }
    }
}
