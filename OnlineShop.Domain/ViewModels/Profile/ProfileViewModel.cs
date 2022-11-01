using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Input age")]
        [Range(0, 150, ErrorMessage = "Age should be more than 0 and less than 150")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Input address")]
        [MinLength(5, ErrorMessage = "Address should be more than 5")]
        [MaxLength(200, ErrorMessage = "Address should me less than 200")]
        public string Address { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
}
