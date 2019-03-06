using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.MvcWebUI.Entities;
using ProjectDemo.MvcWebUI.Models;

namespace ProjectDemo.MvcWebUI.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Details(string id)
        {
            var model = new UserDetailsViewModel
            {
                UserName = HttpContext.User.Identity.Name,
                UserId = id
            };
            return View(model);
        }
    }
}