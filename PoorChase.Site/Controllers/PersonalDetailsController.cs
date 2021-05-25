using Microsoft.AspNetCore.Mvc;
using PoorChase.Entities;
using PoorChase.Services;

namespace PoorChase.Site
{
    [Route("details")]
    public class PersonalDetailsController : Controller
    {
        IUserService _userService;

        public PersonalDetailsController(IUserService userService) => _userService = userService;

        public IActionResult Index()
        {
            var model = new PersonalDetailsViewModel();
            var user = _userService.GetByUserName(Request.Cookies["User"]);
            if (user != null)
                model = new PersonalDetailsViewModel(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(PersonalDetailsViewModel newUserDetails)
        {
            //if a user is logged in to system, the post is for details changes
            if (newUserDetails.IsUserLoggedIn)
            {
                //get the instance of the logged user
                var user = _userService.GetByUserName(Request.Cookies["User"]);
                //change the data
                user.FirstName = newUserDetails.FirstName;
                user.LastName = newUserDetails.LastName;
                user.BirthDate = newUserDetails.BirthDate;
                user.Email = newUserDetails.Email;
                user.Password = newUserDetails.Password;
                _userService.EditDetails(user);
            }
            //else it is for creating new account
            else
            {
                //if user name already taken (all other validations take place in client side)
                if (!ModelState.IsValid)
                {
                    return View(newUserDetails);
                }
                //create the new account
                _userService.AddUser(new User
                {
                    FirstName = newUserDetails.FirstName,
                    LastName = newUserDetails.LastName,
                    BirthDate = newUserDetails.BirthDate,
                    UserName = newUserDetails.UserName,
                    Email = newUserDetails.Email,
                    Password = newUserDetails.Password
                });
                //log account in
                Response.Cookies.Append("User", newUserDetails.UserName);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
