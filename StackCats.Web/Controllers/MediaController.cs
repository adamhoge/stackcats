using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StackCats.Web.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Images()
        {
            return View();
        }

        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Music()
        {
            return View();
        }
    }
}