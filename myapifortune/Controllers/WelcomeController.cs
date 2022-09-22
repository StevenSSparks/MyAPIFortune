using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Interfaces;

namespace MyAPIFortune.Controllers
{
    public class WelcomeController : Controller
    {

        private readonly IAppVersionService _appVersionService;

        public WelcomeController(IAppVersionService appVersionService)
        {
            _appVersionService = appVersionService;
        }

        [EnableCors("CORSPolicy")]
        [Route("/")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            var v = new Models.WelcomeVM { AppVersion = _appVersionService.Version };

            // Returns a Static HTML Page
            return View(v);
        }




    }
}
