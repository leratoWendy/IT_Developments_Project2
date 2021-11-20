using PictureShare.Context;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Data_Components.implementation
{
    public class AlbumsImpl : IAlbums
    {
        private ApplicationDatabaseContext dbContext;

        public AlbumsImpl(ApplicationDatabaseContext a)
        {
            dbContext = a;
        }
        public void createAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public void deleteAlbum(string name)
        {
            throw new NotImplementedException();
        }
    }
}
