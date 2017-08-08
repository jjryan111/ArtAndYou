using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
namespace ArtAndYou.Models
{
    public class Medium
    {
        [Required]
        [Key]
        public string medium { get; set; }
        [Key]
        public string firstName { get; set; }
        public Medium()
        {
            this.medium = medium;
            this.firstName = firstName;
        }
    }
}