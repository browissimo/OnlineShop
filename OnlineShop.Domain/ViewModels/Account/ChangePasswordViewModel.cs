﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should be more than 5 or equal 5 ")]
        public string NwePassword { get; set; }
    }
}
