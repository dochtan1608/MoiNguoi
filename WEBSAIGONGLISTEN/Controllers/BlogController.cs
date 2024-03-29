using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WEBSAIGONGLISTEN.Models;
using WEBSAIGONGLISTEN.Repositories;

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


    }
}
