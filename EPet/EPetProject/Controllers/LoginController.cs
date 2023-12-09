using EPetProject.Business;
using EPetProject.DomainObjects;
using EPetProject.DTO.Login;
using EPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPetProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Login]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Treatment"); 
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginCheck(CheckClinicRequest request)
        {
            ClinicBusiness clinicBusiness = new ClinicBusiness();
            String message = clinicBusiness.CheckClinic(request);
            if (message != null)
            {
                TempData["Message"] = message;
                return RedirectToAction("Login");
            }
            clinic clinic = clinicBusiness.LoginClinic(request);
            if (clinic != null)
            {
                Session[SessionKeyManager.LoginKey] = clinic;
                return RedirectToAction("Index");

            }
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult RegisterCheck(RegisterClinicRequest request)
        {
            ClinicBusiness userBusiness = new ClinicBusiness();
            String msg = userBusiness.RegisterCheck(request);
            if (msg != null)
            {
                TempData["Message"] = msg;
                return RedirectToAction("Register");
            }
            TempData["Message"] = userBusiness.RegisterClinic(request);
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            Session[SessionKeyManager.LoginKey] = null;
            return RedirectToAction("Login");
        }
    }
}