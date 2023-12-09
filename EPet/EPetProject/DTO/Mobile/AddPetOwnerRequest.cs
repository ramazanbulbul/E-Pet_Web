using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Mobile
{
    public class AddPetOwnerRequest
    {
        public String Id{ get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
    }
}