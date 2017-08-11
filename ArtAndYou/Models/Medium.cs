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
        [Key]
        public string genre { get; set; }
        [Key]
        public string category { get; set; }

        public Medium()
        {
            this.medium = medium;
            this.firstName = firstName;
            this.genre = genre;
            this.category = category;
        }
        private ArtInfoEntities2 db = new ArtInfoEntities2();
        public List<Survey1> Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Survey1 survey1 = db.Survey1.Find(id);
            List<Survey1> thing = db.Survey1.ToList();

            if (survey1 == null)
            {
                return null;
            }
            return thing;
        }

    }
}