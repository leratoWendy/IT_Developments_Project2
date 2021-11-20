using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Data_Components
{
    interface IAlbums
    {
        public void createAlbum(Album album);
        public void deleteAlbum(string name);
    }
}
