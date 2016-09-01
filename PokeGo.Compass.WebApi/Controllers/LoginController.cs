using PokeGo.Compass.Core.Services;
using PokeGo.Compass.WebApi.Models;
using System.Web.Http;

namespace PokeGo.Compass.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private ILoginService _loginService;
        
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("authentication")]
        public string Login(Login login)
        {
            return _loginService.DoLogin(login);
        }
    }
}
