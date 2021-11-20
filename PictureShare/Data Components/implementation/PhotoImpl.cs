using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PictureShare.Context;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Data_Components.implementation
{
    public class PhotoImpl : IPhotos
    {
        private ApplicationDatabaseContext dbContext;
        private IUser user;

        public PhotoImpl(ApplicationDatabaseContext a, IUser b)
        {
            dbContext = a;
            user = b;
        }
        public int deletePhoto(string name)
        {
            int count = dbContext.Database.ExecuteSqlRaw($"delete from photos where name='"+name+"'");
            return count;
        }

        public void sendPhoto(string name)
        {
            throw new NotImplementedException();
        }

        public async void uploadPhoto(string email,string tag, string location, string capturedby, DateTime date, IFormFile pic)
        {
            User userUp = user.getUser(email);
            Photo piccture = new Photo();
            var input = new MemoryStream();
            pic.CopyToAsync(input);
            piccture.photo_id = new Guid();
            piccture.photo = input.ToArray();
            piccture.name = System.IO.Path.GetFileName(pic.FileName);
            piccture.tag = tag;
            piccture.geolocation = location;
            piccture.capturedBy = capturedby;
            piccture.capturedDate = date;
            piccture.user = await dbContext.user.FindAsync(userUp.user_id);

            dbContext.photos.Add(piccture);
            dbContext.SaveChangesAsync();

        }
    }
}
