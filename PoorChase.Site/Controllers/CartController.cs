using Microsoft.AspNetCore.Mvc;
using PoorChase.Entities;
using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    [Route("cart")]
    public class CartController : Controller
    {
        IProductService _productService;
        ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var model = GetProductsInCartFromCookies();
            ViewData["IsUser"] = Request.Cookies["User"];
            return View(model);
        }

        [HttpPost]
        public IActionResult Buy()
        {
            foreach (var product in GetProductsInCartFromCookies())
            {
                _cartService.Buy(product.Id, Request.Cookies["User"]);
            }
            Response.Cookies.Delete("Cart");
            //Say congrats for successfull purchase
            TempData["PopUp"] = true;
            return RedirectToAction("Index");
        }

        [HttpPost("add{id}")]
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();

            if (Request.Cookies["Cart"] == null)
                Response.Cookies.Append("Cart", $"{id};");
            else
            {
                var productsCookie = Request.Cookies["Cart"] + $"{id};";
                Response.Cookies.Delete("Cart");
                Response.Cookies.Append("Cart", productsCookie);
            }
            _cartService.AddToCart(id, Request.Cookies["User"]);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("remove{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();

            var oldCookieString = Request.Cookies["Cart"];
            var newCookieString = oldCookieString.Remove(oldCookieString.IndexOf($"{id}"), id.ToString().Length + 1);
            Response.Cookies.Delete("Cart");
            Response.Cookies.Append("Cart", newCookieString);
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        private List<Product> GetProductsInCartFromCookies()
        {
            var products = new List<Product>();
            if (Request.Cookies["Cart"] != null)
            {
                var productIDs = Request.Cookies["Cart"].Split(';');
                foreach (var stringId in productIDs)
                {
                    if (!string.IsNullOrWhiteSpace(stringId))
                        products.Add(_productService.GetById(int.Parse(stringId)));
                }
            }
            return products;
        }
    }
}
