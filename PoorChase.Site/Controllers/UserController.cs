using Microsoft.AspNetCore.Mvc;
using PoorChase.Entities;
using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    [Route("user")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Login(model.LoginUserName, model.Password);
                Response.Cookies.Append("User", model.LoginUserName);
                TempData.Remove("ErrorMessage");
            }
            else
                TempData["ErrorMessage"] = "User name or password is incorrect";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
