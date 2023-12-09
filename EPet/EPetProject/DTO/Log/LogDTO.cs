using EPetProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Log
{
    public class LogDTO
    {
        public int ID { get; set; }
        public clinic Admin{ get; set; }
        public clinic Target { get; set; }
        public String Action { get; set; }
    }
}