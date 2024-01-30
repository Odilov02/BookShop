using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UserCredential
    {
        public string phoneNumber { get; set; } 

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "comfirm password not found")]
        public string ConfirmPassword { get; set; }

    }
}
