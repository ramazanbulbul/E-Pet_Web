using EPetProject.Business;
using EPetProject.DomainObjects;
using EPetProject.DTO.Log;
using EPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPetProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        [Login]
        [Admin]
        public ActionResult Index()
        {
            ClinicBusiness clinicBusiness = new ClinicBusiness();
            List<clinic> allClinics = clinicBusiness.getAll();
            ViewBag.Clinics = allClinics;
            return View();
        }

        [Login]
        [Admin]
        public ActionResult Log()
        {
            LogBusiness logBusiness = new LogBusiness();
            List<LogDTO> allLogs = logBusiness.getAll();
            ViewBag.Logs = allLogs;
            return View();
        }

        [Login]
        [Admin]
        public ActionResult SetVerify(int id)
        {
            ClinicBusiness userBusiness = new ClinicBusiness();
            userBusiness.SetVerify(id);
            return RedirectToAction("Index");
        }
        [Login]
        [Admin]
        public ActionResult Delete(int id)
        {
            ClinicBusiness userBusiness = new ClinicBusiness();
            userBusiness.Delete(id);
            return RedirectToAction("Index");
        }
    }
}