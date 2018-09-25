using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public bool AllowHtml { get; set; }
        public int PictureId { get; set; }

        public string SpeakerUrl
        {
            get
            {
                return new 
                       Utils().GenerateSlug(string.Format("{0}-{1}-{2}", FirstName, LastName, PictureId));
            }
        }


        public virtual List<Session> Sessions { get; set; }
    }
}