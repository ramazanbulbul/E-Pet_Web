using EPetProject.Business;
using EPetProject.DomainObjects;
using EPetProject.DTO.Treatment;
using EPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPetProject.Controllers
{
    public class TreatmentController : Controller
    {
        // GET: Treatment
        [Login]
        public ActionResult Index()
        {
            TreatmentBusiness treatmentBusiness = new TreatmentBusiness();
            List<TreatmentDTO> allTreatments = treatmentBusiness.getAll();
            ViewBag.Treatments = allTreatments;
            return View();
        }
        [Login]
        public ActionResult Add()
        {

            return View();
        }
        [Login]
        public ActionResult AddCheck(TreatmentAddRequest request)
        {
            TreatmentBusiness treatmentBusiness = new TreatmentBusiness();
            String msg = treatmentBusiness.AddCheck(request);
            if (msg != null)
            {
                TempData["Message"] = msg;
                return RedirectToAction("Add");
            }
            treatmentBusiness.Add(request);
            return RedirectToAction("Index");
        }
        [Login]
        public ActionResult Search()
        {
            return View();
        }
        [Login]
        public ActionResult SearchByPet(SearchDTO request)
        {
            TreatmentBusiness treatmentBusiness = new TreatmentBusiness();
            List<TreatmentDTO> allTreatments = treatmentBusiness.getTreatmentByPetId(request);
            ViewBag.Treatments = allTreatments;
            return View();
        }
    }
}