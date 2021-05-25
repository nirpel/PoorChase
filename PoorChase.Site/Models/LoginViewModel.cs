using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "* Required")]
        [LoginValidation]
        public string LoginUserName { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Password { get; set; }
    }
}
