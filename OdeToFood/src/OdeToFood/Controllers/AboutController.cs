using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    //attribute based routing
    [Route("about")]
    //if your route names match the methods and class names exactly, you can use tokesn
    //[Route("[controller]")]
    //[Route("[controller]/[action]")] // if you want to include all method names as actions 
    public class AboutController
    {
        //attribute based routing is good for easy to use custom routing
        [Route("")]
        //[Route("[action]")]
        public string Phone()
        {
            return "1+555-555-5555";
        }
        [Route("address")] // if we leave this attribute off, MVC won't know whether to go to Phone or Address
        public string Address()
        {
            return "USA";
        }
    }
}
