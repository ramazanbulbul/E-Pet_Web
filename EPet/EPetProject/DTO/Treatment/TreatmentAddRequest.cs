using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Treatment
{
    public class TreatmentAddRequest
    {
        public int PetId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}