using Ecomm_b4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm_b4.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            List<BaseProduct> baseProducts = new List<BaseProduct>();

            BaseProduct baseProduct = new BaseProduct();
            baseProduct.name = "Samsung";
            baseProduct.tag = "Samsung";
            baseProduct.Category.CategoryId = 1;
            baseProduct.Category.Category = "Smartphone";
            baseProduct.price = 15000;

            BaseReview baseReview = new BaseReview();
            baseReview.Review = "1st review";
            baseProduct.baseReviews.Add(baseReview);
            baseReview = new BaseReview();
            baseReview.Review = "2st review";
            baseProduct.baseReviews.Add(baseReview);
            baseProducts.Add(baseProduct);

            baseProduct = new BaseProduct();
            baseProduct.name = "Samsung 2";
            baseProduct.tag = "Samsung 2";
            baseProduct.Category.CategoryId = 1;
            baseProduct.Category.Category = "Smartphone";
            baseProduct.price = 15000;
            baseProducts.Add(baseProduct);
            return Json(baseProducts);
        }
    }
}
