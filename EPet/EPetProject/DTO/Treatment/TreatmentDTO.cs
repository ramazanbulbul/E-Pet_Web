using EPetProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Treatment
{
    public class TreatmentDTO
    {
        public int Id { get; set; }
        public pet Pet{ get; set; }
        public clinic Clinic { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime? DateTime{ get; set; }
    }
}