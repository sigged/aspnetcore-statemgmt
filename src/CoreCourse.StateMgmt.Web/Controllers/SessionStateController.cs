using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreCourse.StateMgmt.Web.Controllers
{
    public class SessionStateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}