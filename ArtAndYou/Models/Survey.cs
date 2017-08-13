using System;
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
        public string Classification { get; set; }
        [Key]
        public string Century { get; set; }
        [Key]
        public string Culture { get; set; }
        //[Key]
        //public string name { get; set; }
        
        
        // JJ: THis was stuff I was playing with and hadn't called yet


        /*does this do anything? Commented out as test 8/12/2017 10:42 AM ---->
         * 
        public Survey()
        {
            //            this.question = question;

            //Christopher commented out the next three lines 8/12/2017 9:57 AM - don't seem to be doing anything?
            //this.cent = cent;
            //this.cult = cult;
            //this.classification = classification;
        }
        public string ConCatChoice(string question, string classification, string choice)
        {
            return "Survey" + question + classification + choice;
        }

        <----  does this do anything? Commented out as test 8/12/2017 10:42 AM */
    }
}
 