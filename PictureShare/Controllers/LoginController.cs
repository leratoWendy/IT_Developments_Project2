using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureShare.Context;
using PictureShare.Data_Components;
using PictureShare.Models;
using System.Linq;



namespace PictureShare.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDatabaseContext db;
        IUser iuser;

        public LoginController(ApplicationDatabaseContext a, IUser b)
        {
            db = a;
            iuser = b;
        }

     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string user_name, string password)
        {
            var person = db.user.Where(x => x.user_name.Equals(user_name) && x.password.Equals(password));
            if (person.Count() == 1) {
                
                User user = iuser.getUser(user_name);
                HttpContext.Session.SetString("email", user.user_name);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid) {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return ViewBag("Error something went wrong");
        }
    }
}
