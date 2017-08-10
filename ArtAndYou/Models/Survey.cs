using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ArtAndYou.Models
{

    public class Survey
    {
        [Required]
        [Key]
        public string medium { get; set; }
        [Key]
        public string firstName { get; set; }
        [Key]
        public string genre { get; set; }
        [Key]
        public string category { get; set; }

        public Survey()
        {
            this.medium = medium;
            this.firstName = firstName;
            this.genre = genre;
            this.category = category;
        }
    }
}