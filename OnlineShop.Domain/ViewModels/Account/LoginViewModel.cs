using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Input name")]
        [MaxLength(20, ErrorMessage = "Name should be equal 20 or less than 20")]
        [MinLength(5, ErrorMessage = "Name should be 5 or more than 5")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
