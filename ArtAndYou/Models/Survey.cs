﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtAndYou.Models
{
    public class Survey
    {
        [Required]
        [Key]
        public string classification { get; set; }
        [Key]
        public string cent { get; set; }
        [Key]
        public string cult { get; set; }
        [Key]
        public string name { get; set; }

        public Survey()
        {
//            this.question = question;
            this.cent = cent;
            this.cult = cult;
            this.classification = classification;
        }
        public string ConCatChoice(string question, string classification, string choice)
        {
            return "Survey" + question + classification + choice;
        }
    }
}