using Microsoft.AspNetCore.Identity;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDemo.MvcWebUI.Entities
{
    public class CustomIdentityUser:IdentityUser
    {
        public string ProfileImageId { get; set; }
       
    }
}
