using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoorChase.Entities;
using PoorChase.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    [Route("product")]
    public class ProductController : Controller
    {
        IProductService _productService;
        IUserService _userService;
        IWebHostEnvironment _hosting;

        public ProductController(IProductService productService, IUserService userService,
            IWebHostEnvironment webHost)
        {
            _productService = productService;
            _userService = userService;
            _hosting = webHost;
        }

        [HttpGet("publish")]
        public IActionResult Index()
        {
            return View(new ProductViewModel());
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish(ProductViewModel model)
        {
            IFormFile[] uploadedImages = { model.Picture1, model.Picture2, model.Picture3 };
            string[] filePaths = new string[3];
            for (int i = 0; i < uploadedImages.Length; i++)
            {
                if (uploadedImages[i] != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedImages[i].FileName);
                    filePaths[i] = Path.Combine(_hosting.WebRootPath, "images\\products", fileName);
                    using (var fs = new FileStream(filePaths[i], FileMode.Create))
                    {
                        await uploadedImages[i].CopyToAsync(fs);
                    }
                }
            }
            Product product = new Product
            {
                Date = DateTime.Now,
                LongDescription = model.LongDescription,
                OwnerId = _userService.GetByUserName(Request.Cookies["User"]).Id,
                Price = model.Price,
                ShortDescription = model.ShortDescription,
                State = ProductState.Available,
                Title = model.Title,
                PicturePath1 = filePaths[0],
                PicturePath2 = filePaths[1],
                PicturePath3 = filePaths[2]
            };
            _productService.AddProduct(product);
            TempData["PopUp"] = true;
            return RedirectToAction("Index");
        }
    }
}
