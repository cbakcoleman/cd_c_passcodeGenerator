using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace cd_c_passcodeGenerator
{
    public class HomeController : Controller
    {
        private string GeneratePasscode(int size)
        {
            Random rando = new Random();
            string values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            string result = "";
            for (var i = 0; i < size; i++)
                result += values[rando.Next(values.Length)];
            return result;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("passcode") == null)
                HttpContext.Session.SetString("passcode", "Generate a Passcode!");
            if(HttpContext.Session.GetInt32("times") == null)
                HttpContext.Session.SetInt32("times", 0);

            ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            ViewBag.Times = HttpContext.Session.GetInt32("times");

            return View();
            
            // PasscodeGenerator newPasscode = new PasscodeGenerator();
            // string Passcode = newPasscode.GeneratePasscode(true, true, true, true, 16);
            // return View("Index", Passcode);
        }

        [HttpGet("new")]
        public IActionResult NewPasscode()
        {
            int? times = HttpContext.Session.GetInt32("times");
            times++;
            HttpContext.Session.SetInt32("times", (int)times);
            HttpContext.Session.SetString("passcode", GeneratePasscode(14));
            return RedirectToAction("Index");
        }
    }
}