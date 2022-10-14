using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Interfaces;

namespace MyAPIFortune.Controllers
{
    public class WelcomeController : Controller
    {

        private readonly IAppVersionService _appVersionService;
        private readonly IGetFortune _getFortune;

        public WelcomeController(IAppVersionService appVersionService, IGetFortune getFortune)
        {
            _appVersionService = appVersionService;
            _getFortune = getFortune;
        }

        [EnableCors("CORSPolicy")]
        [Route("/")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            var v = new Models.WelcomeVM { AppVersion = _appVersionService.Version };
            v.RandomFortune = _getFortune.ReturnTimeBasedFortune().phrase;

            // Returns a Static HTML Page
            return View(v);
        }




    }
}
