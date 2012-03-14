using System;
using System.Web.Mvc;
using DoItRight.Models;
using DoItRight_Domain;

namespace DoItRight.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;

        public HomeController(ProductRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }
        public ActionResult Index()
        {
            var model = new FeaturedProductsViewModel();

            var productService = new ProductService(_repository);
            var featuredProducts = productService.GetFeaturedProducts(User);
            foreach (var product in featuredProducts)
            {
                var productViewModel = new ProductViewModel(product);
                model.Products.Add(productViewModel);
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
