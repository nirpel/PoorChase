using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoorChase.Services;
using System.Linq;

namespace PoorChase.Site
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var p = _productService.GetProducts().ToList();
            switch (Request.Cookies["SortBy"])
            {
                case "title":
                    p = p.OrderBy(x => x.Title).ToList();
                    break;
                case "date":
                    p = p.OrderBy(x => x.Date).ToList();
                    break;
                default:
                    break;
            }
            return View(p);
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            if (Request.Cookies["Cart"] == null)
                Response.Cookies.Append("Cart", $"{id}");
            else
            {
                var productsCookie = Request.Cookies["Cart"] + $";{id}";
                Response.Cookies.Delete("Cart");
                Response.Cookies.Append("Cart", productsCookie);
            }
            _cartService.AddToCart(product.Id, Request.Cookies["User"]);
            return RedirectToAction("Index");
        }
    }
}
