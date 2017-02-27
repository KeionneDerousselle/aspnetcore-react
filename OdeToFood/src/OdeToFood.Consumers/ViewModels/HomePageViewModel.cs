using System.Collections.Generic;
using OdeToFood.Consumers.Entities;

namespace OdeToFood.Consumers.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
