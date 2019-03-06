using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProjectDemo.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectDemo.MvcWebUI.ViewComponents
{
    public class UserSummaryViewComponent : ViewComponent
    {
    
        public ViewViewComponentResult Invoke()
        {

            UserDetailsViewModel model = new UserDetailsViewModel
            {
                UserName = HttpContext.User.Identity.Name,
                UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            
            return View(model);
        }
       
    }
}
