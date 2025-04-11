using Microsoft.AspNetCore.Mvc;
using QnAB4.Model;

namespace QnAB4.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("ValidateUser")]
        public IActionResult ValidateUser(string UserName, string Password)
        {
            return Ok(ServiceToken.GenerateServiceToken());
            //return View();
        }
    }
}
