using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class NavLinkViewModel
    {
        public NavLinkViewModel() { }

        public NavLinkViewModel(string currentViewName, string requiredViewName, string iconName, 
            string linkTitle, string controller, string action)
        {
            CurrentViewName = currentViewName;
            RequiredViewName = requiredViewName;
            IconName = iconName;
            LinkTitle = linkTitle;
            Controller = controller;
            Action = action;
        }

        public string CurrentViewName { get; set; }
        public string RequiredViewName { get; set; }
        public string IconName { get; set; }
        public string LinkTitle { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
