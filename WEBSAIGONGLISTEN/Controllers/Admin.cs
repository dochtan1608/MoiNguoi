using Microsoft.AspNetCore.Mvc;

namespace WEBSAIGONGLISTEN.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
