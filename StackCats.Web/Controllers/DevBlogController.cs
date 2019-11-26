using Microsoft.AspNetCore.Mvc;

namespace StackCats.Web.Controllers
{
    public class DevBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}