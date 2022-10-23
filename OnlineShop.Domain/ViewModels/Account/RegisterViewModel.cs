using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Input name")]
        //[MaxLength(20, ErrorMessage = "Name should be equal 20 or less than 20")]
        //[MinLength(5, ErrorMessage = "Name should be 5 or more than 5")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        //[MinLength(5, ErrorMessage = "Password should be more than 5 or equal 5 ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Passwords don't match111")]
        //[MinLength(5, ErrorMessage = "Password should be more than 5 or equal 5 ")]
        public string PasswordConfirm { get; set; }
        

        
    }
}
