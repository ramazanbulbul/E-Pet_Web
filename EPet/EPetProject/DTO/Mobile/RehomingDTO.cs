using EPetProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Mobile
{
    public class RehomingDTO
    {
        public int Id { get; set; }
        public String PetName{ get; set; }
        public String Description{ get; set; }
        public String OwnerName { get; set; }
        public String PhoneNumber { get; set; }
        public String Adress { get; set; }
        public String ImageUrl { get; set; }
    }
}