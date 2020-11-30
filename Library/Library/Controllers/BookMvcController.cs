using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class BookMvcController : BaseController
    {
        public BookMvcController(ILogger<BookMvcController> logger)
            : base(logger)
        {
        }
        public IActionResult Books()
        {
            return View();
        }
    }
}
