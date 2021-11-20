using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Models
{
    public class Photo
    {
        [Key]
        [Column("photo_id")]
        public Guid photo_id { get; set; }

        [Required]
        [Column("Photo")]
        public byte[] photo { get; set; }

        [Column("name")]
        [Required]
        public string name { get; set; }

        [Column("Geolocation")]
        [Required]
        public string geolocation { get; set;}


        [Column("Tag")]
        [Required]
        public string tag { get; set; }

        [Column("Date_Captured")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime capturedDate { get; set; }


        [Column("Captured_By")]
        [Required]
        public string capturedBy { get; set; }

        public Guid user_id { get; set; }
        [Required]
        [ForeignKey("user_id")]
        public User user { get; set; }
    }
}
