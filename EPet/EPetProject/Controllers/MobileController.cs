using EPetProject.Business;
using EPetProject.DomainObjects;
using EPetProject.DTO.Mobile;
using EPetProject.Views.Mobile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPetProject.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        [HttpPost]
        public ActionResult AddPetOwner(AddPetOwnerRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.AddPetOwner(request);
            return View();
        }
        public ActionResult GetOwnerPets(String uid)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            List<PetDTO> pets = mobileBusiness.getOwnerPets(uid);
            return Json(pets);
        }
        public ActionResult GetPetTreatment(int id)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            List<MTreatmentDTO> pets = mobileBusiness.getPetTreatment(id);
            return Json(pets);
        }
        [HttpPost]
        public ActionResult AddRehomingPet(RehomingPetRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.addRehomingPet(request);
            return View();
        }
        public ActionResult getRehomingPet()
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            List<RehomingDTO> pets = mobileBusiness.GetAllRehomingPets();
            return Json(pets);
        }
        [HttpPost]
        public ActionResult isRehomingPet(int PetId)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            TempData["message"] = mobileBusiness.isRehomingPet(PetId);
            return View();
        }
        [HttpPost]
        public ActionResult setUsername(SetUsernameRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.setUsername(request);
            return View();
        }
        [HttpPost]
        public ActionResult setPhoneNumber(SetPhoneNumberRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.setPhoneNumber(request);
            return View();
        }
        [HttpPost]
        public ActionResult setAdress(SetAdressRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.setAdress(request);
            return View();
        }
        [HttpPost]
        public ActionResult deleteAccount(String Id)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.deleteAccount(Id);
            return View();
        }
        public ActionResult GetQrCodeDetail(int id)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            List<QrCodeDetailDTO> detailDTOs =  mobileBusiness.getQrCodeDetail(id);
            return Json(detailDTOs);
        }

        [HttpPost]
        public ActionResult AddPet(AddPetRequest request)
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            mobileBusiness.AddPet(request);
            return View();
        }
        public ActionResult getClinicLoc()
        {
            MobileBusiness mobileBusiness = new MobileBusiness();
            return Json(mobileBusiness.getClinicLoc());
        }
    }
}