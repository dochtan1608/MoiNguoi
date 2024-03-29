using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories;

namespace WEBSAIGONGLISTEN.Controllers
{
    public class BlogController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogController(IProductRepository productRepository,
        ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        // Hiển thị danh sách sản phẩm 
        public async Task<IActionResult> Index()

        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        // Hiển thị thông tin chi tiết sản phẩm (XEM THÊM)
        public async Task<IActionResult> Display(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Action để xử lý tìm kiếm sách
        public ActionResult Search(string keyword)
        {
            // Kiểm tra xem từ khóa tìm kiếm có tồn tại không
            if (!string.IsNullOrEmpty(keyword))
            {
                // Tìm kiếm sách theo từ khóa
                var searchedBooks = data.Saches.Where(s => s.tensach.Contains(keyword));
                if (searchedBooks.Count() == 0)
                {
                    ViewBag.Message = "Khong tim thay sach";
                }

                // Trả về view hiển thị kết quả tìm kiếm
                return View("ListSach", searchedBooks);
            }
            else
            {
                // Nếu từ khóa rỗng, trả về trang danh sách sách ban đầu
                return RedirectToAction("ListSach");
            }
        }

        // Loại bỏ bối cảnh dữ liệu để tránh rò rỉ tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SearchAutocomplete(string term)
        {
            var suggestedBooks = data.Saches
                                     .Where(s => s.tensach.ToLower().Contains(term.ToLower()))
                                     .Select(s => s.tensach)
                                     .ToList();
            return Json(suggestedBooks, JsonRequestBehavior.AllowGet);
        }

    }
}
