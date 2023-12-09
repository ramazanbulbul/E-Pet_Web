using EPetProject.DomainObjects;
using EPetProject.DTO.Treatment;
using EPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.Business
{
    public class TreatmentBusiness
    {
        public List<TreatmentDTO> getAll()
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<TreatmentDTO> allTreatments = new List<TreatmentDTO>();
            foreach (treatment treatment in db.treatment.OrderByDescending(P => P.Date).ToList())
            {
                TreatmentDTO treatmentDTO = new TreatmentDTO();
                treatmentDTO.Id = treatment.Id;
                treatmentDTO.Title = treatment.Title;
                treatmentDTO.Description = treatment.Descr;
                treatmentDTO.Clinic = db.clinic.Where(p => p.Id == treatment.ClinicId).SingleOrDefault();
                treatmentDTO.Pet = db.pet.Where(p => p.Id == treatment.PetId).SingleOrDefault();
                treatmentDTO.DateTime = treatment.Date;
                allTreatments.Add(treatmentDTO);
            }
            return allTreatments;
        }

        public String AddCheck(TreatmentAddRequest request)
        {

            if (String.IsNullOrEmpty(request.Title) || String.IsNullOrEmpty(request.Description) || request.PetId == 0)
            {
                return "Lütfen boş alan bırakmayınız";
            }
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            pet Pet = db.pet.Where(p => p.Id == request.PetId).SingleOrDefault();
            if (Pet == null)
            {
                return "Lütfen işlem yaptığınız hayvanın Id'sini kontrol ediniz!";
            }
            return null;
        }

        public List<TreatmentDTO> getTreatmentByPetId(SearchDTO request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<TreatmentDTO> allTreatments = new List<TreatmentDTO>();
            foreach (treatment treatment in db.treatment.Where(p=>p.PetId == request.Id).OrderByDescending(P=>P.Date).ToList())
            {
                TreatmentDTO treatmentDTO = new TreatmentDTO();
                treatmentDTO.Id = treatment.Id;
                treatmentDTO.Title = treatment.Title;
                treatmentDTO.Description = treatment.Descr;
                treatmentDTO.Clinic = db.clinic.Where(p => p.Id == treatment.ClinicId).SingleOrDefault();
                treatmentDTO.Pet = db.pet.Where(p => p.Id == treatment.PetId).SingleOrDefault();
                treatmentDTO.DateTime = treatment.Date;
                allTreatments.Add(treatmentDTO);
            }
            return allTreatments;
        }

        public void Add(TreatmentAddRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            clinic user = (clinic)HttpContext.Current.Session[SessionKeyManager.LoginKey];
            treatment treatment = new treatment();
            treatment.PetId = request.PetId;
            treatment.ClinicId = user.Id;
            treatment.Title = request.Title;
            treatment.Descr = request.Description;
            treatment.Date = DateTime.Now;
            db.treatment.Add(treatment);
            db.SaveChanges();
        }
    }
}