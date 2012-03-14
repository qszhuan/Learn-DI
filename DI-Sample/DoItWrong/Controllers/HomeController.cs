using System.Web.Mvc;
using DoItWrong.Services;

namespace DoItWrong.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var isInRole = User.IsInRole("PreferredCustomer");
            var productService = new ProductService();
            var featuredProducts = productService.GetFeaturedProducts(isInRole);
            ViewData["Products"] = featuredProducts;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
