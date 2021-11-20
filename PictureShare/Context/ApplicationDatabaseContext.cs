using Microsoft.EntityFrameworkCore;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Context
{
    public class ApplicationDatabaseContext:DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) :base(options)
        {

        }

        public DbSet<Photo> photos { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Album> albums { get; set; }

      
    }
}
