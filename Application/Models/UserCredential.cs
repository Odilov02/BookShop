using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Models
{
    public class UserCredential
    {
        public string phoneNumber { get; set; } = "";

        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "comfirm password not found")]
        public string ConfirmPassword { get; set; } = "";

    }
}
