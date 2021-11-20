using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PictureShare.Context;
using PictureShare.Data_Components;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDatabaseContext db;
        IPhotos pic;

        public HomeController(ILogger<HomeController> logger, ApplicationDatabaseContext database, IPhotos img)
        {
            _logger = logger;
            db = database;
            pic = img;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("email", HttpContext.Session.GetString("email"));
            List<Photo> photos = db.photos.ToList();
            return View(photos);
        }

        [HttpPost]
        public IActionResult share()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null) {
                return NotFound();
            }

            var photo = db.photos.Find(id);
            if (photo != null) {
                return View(photo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePhoto(Photo pic)
        {
            if (ModelState.IsValid) {
                db.photos.Remove(pic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View("Delete");
        }

        public IActionResult upload()
        {
            return View();
        }

        [HttpPost]
        public async void Upload(Photo pic, IFormFile img)
        {
            string user_email = Request.Form["user_email"];
            User person = db.user.Where(x => x.user_name.Equals(user_email)).FirstOrDefault();
            MemoryStream inputStream = new MemoryStream();
            _ = img.CopyToAsync(inputStream);
            pic.photo = inputStream.ToArray();
            pic.photo_id = new Guid();
            pic.user = db.user.Where(x => x.user_id.Equals(person.user_id)).FirstOrDefault();
            if (pic != null)
            {
                db.Add(pic);
                _ =await db.SaveChangesAsync();
                RedirectToAction("Index");
            }
            RedirectToAction("upload");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
