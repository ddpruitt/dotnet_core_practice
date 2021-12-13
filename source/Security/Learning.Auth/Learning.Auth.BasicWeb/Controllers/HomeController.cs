using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Auth.BasicWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {

            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "darren"),
                new Claim(ClaimTypes.Email, "darren@dp.com"),
                new Claim("Grandma.Says", "He's a Good Boy")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "darren k pruitt"),
                new Claim("DrivingLicense", "12387645"),
                new Claim("DrivingLicenseState", "TX")
            };

            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Driver Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return Redirect("Index");
        }

        
    }
}