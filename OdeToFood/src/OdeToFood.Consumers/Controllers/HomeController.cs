using Microsoft.AspNetCore.Mvc;
using OdeToFood.Consumers.Services;
using OdeToFood.Consumers.ViewModels;

namespace OdeToFood.Consumers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _data;
        private IGreeter _greeter;

        public HomeController(IRestaurantData data, IGreeter greeter)
        {
            _data = data;
            _greeter = greeter;
        }

        public IActionResult GetRestaurants()
        {
            var viewModel = new HomePageViewModel
            {
                CurrentMessage = _greeter.GetGreeting(),
                Restaurants = _data.GetAll()
            };

            return new ObjectResult(viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = _data.Get(id);
            if (model == null)
            {
                //return new NotFoundResult();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
