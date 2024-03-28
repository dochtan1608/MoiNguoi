using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using WEBSAIGONGLISTEN.Models;

namespace WEBSAIGONGLISTEN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Introduce()
        {
            return View();
        }
        public IActionResult Tour()
        {
            return View();
        }

        public IActionResult Search(string query)
        {
            // Thực hiện tìm kiếm trong cơ sở dữ liệu hoặc từ nguồn dữ liệu khác

            if (string.IsNullOrWhiteSpace(query))
            {
                return View(new List<Blog>()); // Trả về một danh sách rỗng hoặc bạn có thể chọn hiển thị một thông báo lỗi/phản hồi.
            }

            var blogs = await _context.Blogs
                                      .Where(b => b.PlaceName.Contains(query)) // 'PlaceName' là tên cột chứa tên địa danh
                                      .ToListAsync();vvvvvv
            // Sau đó, trả về view kết quả tìm kiếm
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
