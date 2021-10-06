using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace cd_c_passcodeGenerator
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            
            PasscodeGenerator newPasscode = new PasscodeGenerator();
            string Passcode = newPasscode.GeneratePasscode(true, true, true, true, 16);
            return View("Index", Passcode);
        }
    }
}