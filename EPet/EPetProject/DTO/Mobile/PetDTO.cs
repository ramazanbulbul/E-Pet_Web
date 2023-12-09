using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.Views.Mobile
{
    public class PetDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Birthday { get; set; }
        public String Type { get; set; }
        public String Breed { get; set; }
        public String OwnerId { get; set; }
        public String ImageUrl { get; set; }
    }
}