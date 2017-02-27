using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    //we use the name 'Home"Controller and 'Index' because they are looked for by default
    public class HomeController : Controller
    {
        private readonly IRestaurantData _data;
        private IGreeter _greeter;

        //public string Index()
        //{
        //    return "Hello, from the HomeController.";
        //}

        //public IActionResult Index()
        //{
        //    var restaurant = new Restaurant
        //    {
        //        Id = 1,
        //        Name = "Test Name"
        //    };

        //    return new ObjectResult(restaurant);
        //}

        //public IActionResult Index()
        //{
        //    var restaurant = new Restaurant
        //    {
        //        Id = 1,
        //        Name = "Test Name"
        //    };

        //    return View(restaurant);
        //}

        public HomeController(IRestaurantData data, IGreeter greeter)
        {
            _data = data;
            _greeter = greeter;
        }

        //public IActionResult Index()
        //{
        //    return View(_data.GetAll());
        //}

        public IActionResult Index()
        {
            var viewModel = new HomePageViewModel
            {
                CurrentMessage = _greeter.GetGreeting(),
                Restaurants = _data.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = _data.Get(id);
            if(model == null)
            {
                //return new NotFoundResult();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
