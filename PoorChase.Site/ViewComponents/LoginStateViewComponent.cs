using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using PoorChase.Entities;
using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class LoginStateViewComponent : ViewComponent
    {
        IUserService _service;

        public LoginStateViewComponent(IUserService service) => _service = service;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!Request.Cookies.ContainsKey("User"))
                return View("Login", new LoginViewModel());

            return View("Logout", new LogoutViewModel
            {
                FirstName = _service.GetByUserName(Request.Cookies["User"]).FirstName,
                DayState = _service.GetCurrentDayState()
            });
        }
    }
}
