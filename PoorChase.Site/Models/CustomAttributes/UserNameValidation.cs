using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class UserNameValidation : ValidationAttribute
    {
        IUserService _userService;

        public UserNameValidation()
        {
            _userService = new UserService();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var details = (PersonalDetailsViewModel)validationContext.ObjectInstance;
            if (_userService.GetByUserName(details.UserName) != null && !details.IsUserLoggedIn)
                return new ValidationResult($"{details.UserName} is already in use.");
            return ValidationResult.Success;
        }
    }
}
