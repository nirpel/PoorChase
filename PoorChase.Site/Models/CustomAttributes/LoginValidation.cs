using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class LoginValidation : ValidationAttribute
    {
        IUserService _userService;

        public LoginValidation() => _userService = new UserService();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var loginDetails = (LoginViewModel)validationContext.ObjectInstance;
            var userDetails = _userService.GetByUserName(loginDetails.LoginUserName);
            if (userDetails == null || userDetails.Password != loginDetails.Password)
                return new ValidationResult("User name or password is incorrect");
            return ValidationResult.Success;
        }
    }
}
