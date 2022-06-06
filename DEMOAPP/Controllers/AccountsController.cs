using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOAPP.Controllers
{

   
    public class AccountsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("Raveendra") && password.Equals("12345"))
            {
                HttpContext.Session.SetString("username", username);
                return View("Success");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Client(string username, string password)
        {
            if (username != null && password != null && username.Equals("Client") && password.Equals("12345"))
            {
                HttpContext.Session.SetString("username", username);
                return View("ClientPage");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }


        public IActionResult BrowerEvent()
        {
            return View();
        }
    }
}
