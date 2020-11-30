using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
            : base(logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {            
            return View();
        }
    }
}
