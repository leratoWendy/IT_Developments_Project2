using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Models
{
    public class Album
    {
      
        [Key]
        public Guid album_id { get; set; }

        [Column("Album_Name")]
        public string album_name { get; set; }

        [Column("Date_created")]
        public DateTime dateCreated { get; set; }

    }
}
