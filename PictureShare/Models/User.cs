using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid user_id { get; set; }

        [Column("email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string user_name { get; set; }


        [Column("name")]
        [Required]
        public string name { get; set; }

        [Column("surname")]
        [Required]
        public string surname { get; set; }

        [Column("contact_number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string contact { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}
