using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Mobile
{
    public class AddPetRequest
    {
        public String Name { get; set; }
        public DateTime? Birthday { get; set; }
        public String Type { get; set; }
        public String Breed { get; set; }
        public String OwnerId { get; set; }
        public String ImageUrl { get; set; }
    }
}