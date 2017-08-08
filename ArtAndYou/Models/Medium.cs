using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ArtAndYou.Models
{

    public class Medium
    {
        [Required]
        [Key]
        public string medium { get; set; }
        [Key]
        public string firstName { get; set; }
        public string genre { get; set; }
        public string category { get; set; }
        public Medium()
        {
            this.medium = medium;
            this.firstName = firstName;
            this.genre = genre;
            this.category = category;
        }
    }
}