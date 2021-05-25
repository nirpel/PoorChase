using PoorChase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class PersonalDetailsViewModel
    {
        public PersonalDetailsViewModel() => IsUserLoggedIn = false;

        public PersonalDetailsViewModel(User user) 
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            BirthDate = user.BirthDate;
            Email = user.Email;
            UserName = user.UserName;
            Password = user.Password;
            ConfirmPassword = user.Password;
            IsUserLoggedIn = true;
        }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = " - Required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = " - Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        [UserNameValidation]
        public string UserName { get; set; }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = " - Required")]
        [StringLength(50)]
        [Compare("Password", ErrorMessage = " Unmatched password")]
        public string ConfirmPassword { get; set; }

        public bool IsUserLoggedIn { get; set; }
    }
}
