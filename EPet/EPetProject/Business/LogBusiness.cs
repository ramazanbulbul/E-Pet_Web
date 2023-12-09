using EPetProject.DomainObjects;
using EPetProject.DTO.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.Business
{
    public class LogBusiness
    {
        public List<LogDTO> getAll()
        {
            List<LogDTO> allLogs = new List<LogDTO>();
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            foreach (log log in db.log.OrderByDescending(p=>p.Id).ToList())
            {
                LogDTO logDTO = new LogDTO();
                logDTO.ID = log.Id;
                logDTO.Admin = db.clinic.Where(p => p.Id == log.AdminId).SingleOrDefault();
                logDTO.Target = db.clinic.Where(p => p.Id == log.TargetId).SingleOrDefault();
                logDTO.Action = log.Action;
                allLogs.Add(logDTO);
            }
            return allLogs;
        }
    }
}