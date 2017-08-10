using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtAndYou.Models
{
    public class Survey
    {
        public string question;
        public string cent;
        public string cult;
        public string classification;

        public Survey()
        {
            this.question = question;
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