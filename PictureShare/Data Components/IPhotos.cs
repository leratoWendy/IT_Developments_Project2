using Microsoft.AspNetCore.Http;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Data_Components
{
    public interface IPhotos
    {
        public void uploadPhoto(string email, string tag, string location, string capturedby, DateTime date, IFormFile pic);
        public int deletePhoto(string name);
        public void sendPhoto(string name);



    }
}
