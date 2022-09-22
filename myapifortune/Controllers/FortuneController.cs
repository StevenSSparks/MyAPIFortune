using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Models;
using MyAPIFortune.Interfaces;
using Microsoft.AspNetCore.Cors;


namespace MyAPIFortune.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class FortuneController : Controller
    {

        private readonly IGetFortune _getFortune;

        public FortuneController(IGetFortune getFortune)
        {
            _getFortune = getFortune;
        }


        [EnableCors("CORSPolicy")]
        [Route("/api/MyFortune")]
        [HttpGet]
        public Fortune MyFortune()
        {
            var value = _getFortune.ReturnTimeBasedFortune();
            return value;
        }


        // GET: FortuneController
        [EnableCors("CORSPolicy")]
        [Route("/api/MyFortune/Random")]
        [HttpGet]
        public Fortune MyRandomFortune()
        {
            var value = _getFortune.ReturnRandomFortune();
            return value;
        }

  
        // GET: FortuneController/Details/5
        [EnableCors("CORSPolicy")]
        [Route("/api/MyFortune/{id}")]
        [HttpGet]
        public Fortune MyFortuenbyID(int id)
        {
            return _getFortune.ReturnFortuneById(id);
        }
      
    }
}
