using EPetProject.DomainObjects;
using EPetProject.DTO.Mobile;
using EPetProject.Views.Mobile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EPetProject.Business
{
    public class MobileBusiness
    {
        public void AddPetOwner(AddPetOwnerRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            mobileuser user = new mobileuser();
            user.Id = request.Id;
            user.Email = request.Email;
            user.Username = request.Username;
            user.PhoneNumber = "";
            user.Adress = "";
            db.mobileuser.Add(user);
            db.SaveChanges();
        }

        public List<PetDTO> getOwnerPets(string uid)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<PetDTO> allPets = new List<PetDTO>();
            foreach (pet pet in db.pet.Where(p => p.OwnerId == uid).ToList())
            {
                PetDTO petDTO = new PetDTO();
                petDTO.Birthday = pet.Birthday.ToString();
                petDTO.Breed = pet.Breed;
                petDTO.Id = pet.Id;
                petDTO.Name = pet.Name;
                petDTO.Type = pet.Type;
                petDTO.ImageUrl = pet.ImageUrl;
                allPets.Add(petDTO);
            }
            return allPets;
        }

        public void addRehomingPet(RehomingPetRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            rehoming rehoming = new rehoming();
            rehoming.PetId = request.PetId;
            rehoming.Descr = request.Desc;
            rehoming.ImageUrl = request.ImageUrl;
            db.rehoming.Add(rehoming);
            db.SaveChanges();
        }

        public List<RehomingDTO> GetAllRehomingPets()
        {
            List<RehomingDTO> rehomings = new List<RehomingDTO>();
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            foreach (rehoming rehoming in db.rehoming.OrderByDescending(p=>p.Id).ToList())
            {
                RehomingDTO rehomingDTO = new RehomingDTO();
                rehomingDTO.Id = rehoming.Id;
                rehomingDTO.ImageUrl = rehoming.ImageUrl ?? "";
                mobileuser user = db.mobileuser.Where(p => p.Id == rehoming.pet.OwnerId).SingleOrDefault();
                rehomingDTO.PetName = rehoming.pet.Name ?? "";
                rehomingDTO.Description = rehoming.Descr;
                if (user!=null)
                {
                    rehomingDTO.OwnerName = user.Username ?? "";
                    rehomingDTO.PhoneNumber = user.PhoneNumber??"";
                    rehomingDTO.Adress = user.Adress ?? "";
                }
                rehomings.Add(rehomingDTO);
            }
            return rehomings;
        }

        public void setPhoneNumber(SetPhoneNumberRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            mobileuser user = db.mobileuser.Where(p => p.Id == request.Id).SingleOrDefault();
            user.PhoneNumber = request.PhoneNumber;
            db.SaveChanges();
        }

        public List<QrCodeDetailDTO> getQrCodeDetail(int id)
        {

            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<QrCodeDetailDTO> details = new List<QrCodeDetailDTO>();
            foreach (pet pet in db.pet.Where(p => p.Id == id).ToList())
            {
                QrCodeDetailDTO detail = new QrCodeDetailDTO();
                detail.Adress = pet.mobileuser.Adress;
                detail.Email = pet.mobileuser.Email;
                detail.PhoneNumber = pet.mobileuser.PhoneNumber;
                detail.Username = pet.mobileuser.Username;
                details.Add(detail);
            }
            return details;
        }

        public void deleteAccount(String id)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            mobileuser user = db.mobileuser.Where(p => p.Id == id).SingleOrDefault();
            if (user != null)
            {
                db.mobileuser.Remove(user);
                db.SaveChanges();
            }
            
        }

        public void setUsername(SetUsernameRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            mobileuser user = db.mobileuser.Where(p => p.Id == request.Id).SingleOrDefault();
            user.Username = request.Username;
            db.SaveChanges();
        }
        public void setAdress(SetAdressRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            mobileuser user = db.mobileuser.Where(p => p.Id == request.Id).SingleOrDefault();
            user.Adress = request.Adress;
            db.SaveChanges();
        }
        public bool isRehomingPet(int petId)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            rehoming rehoming = db.rehoming.Where(p => p.PetId == petId).SingleOrDefault();
            if (rehoming == null)
            {
                return false;
            }
           return true;
            
        }

        public List<MTreatmentDTO> getPetTreatment(int id)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<MTreatmentDTO> allTreatment = new List<MTreatmentDTO>();
            foreach (treatment treatment in db.treatment.Where(p => p.PetId == id).OrderByDescending(p => p.Date).ToList())
            {
                MTreatmentDTO treatmentDTO = new MTreatmentDTO();
                treatmentDTO.ClinicName = treatment.clinic.ClinicName;
                treatmentDTO.Date = treatment.Date.ToString();
                treatmentDTO.Title = treatment.Title;
                treatmentDTO.Description = treatment.Descr;
                allTreatment.Add(treatmentDTO);
            }
            return allTreatment;
        }

        public void AddPet(AddPetRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            pet pet = new pet();
            pet.Name = request.Name;
            pet.OwnerId = request.OwnerId;
            pet.Type = request.Type;
            pet.Birthday = (DateTime) request.Birthday;
            pet.Breed = request.Breed;
            pet.ImageUrl = request.ImageUrl;
            db.pet.Add(pet);
            db.SaveChanges();
        }
        public List<ClinicLocDTO> getClinicLoc()
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            List<ClinicLocDTO> allClinics = new List<ClinicLocDTO>();
            foreach (clinic clinic in db.clinic.Where(p => p.Verify > 1).ToList())
            {
                ClinicLocDTO clinicLoc = new ClinicLocDTO();
                clinicLoc.ClinicName = clinic.ClinicName;
                clinicLoc.Adress = clinic.Adress;
                allClinics.Add(clinicLoc);
            }
            return allClinics;
        }
    }
}