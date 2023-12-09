using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Mobile
{
    public class RehomingPetRequest
    {
        public String Desc { get; set; }
        public int PetId { get; set; }
        public String ImageUrl { get; set; }
    }
}