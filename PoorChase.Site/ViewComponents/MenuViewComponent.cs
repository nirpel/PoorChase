using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string viewName)
        {
            var isUserLoggedIn = Request.Cookies.ContainsKey("User");
            ViewData["View Name"] = viewName;
            return View(isUserLoggedIn);
        }
    }
}
