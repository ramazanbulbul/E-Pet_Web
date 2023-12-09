using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.DTO.Login
{
    public class RegisterClinicRequest
    {
        public string ClinicName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        public string Adress { get; set; }
    }
}