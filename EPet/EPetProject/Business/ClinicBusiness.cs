using EPetProject.DomainObjects;
using EPetProject.DTO.Login;
using EPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPetProject.Business
{
    public class ClinicBusiness
    {
        public String CheckClinic(CheckClinicRequest request)
        {
            //Login kontol işlemlerimizi yapıyoruz
            if (String.IsNullOrEmpty(request.Eposta) || String.IsNullOrEmpty(request.Password))
            {
                return "Lütfen alanları doldurunuz!";
            }
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            request.Password = Utility.EncMD5(request.Password);
            clinic clinic = db.clinic.Where(p => p.Email == request.Eposta && p.Password == request.Password).SingleOrDefault();
            if (clinic == null)
            {
                return "Eposta veya şifreniz yanlış!";
            }
            if (clinic.Verify == 0)
            {
                return "Hesabınız yetkililer tarafından onaylanmayı bekliyor!";
            }
            return null;
        }

        public clinic LoginClinic(CheckClinicRequest request)
        {
            //EntityFramwork Yardımı ile Login işlemimizi yapıyoruz
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            return db.clinic.Where(p => p.Email == request.Eposta && p.Password == request.Password && p.Verify != 0).SingleOrDefault();
        }


        public List<clinic> getAllByNotVerfiy()
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            return db.clinic.Where(p => p.Verify == 0).OrderByDescending(p=>p.Id).ToList();
        }
        public List<clinic> getAll()
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            return db.clinic.OrderByDescending(p => p.Id).ToList();
        }

        public String RegisterCheck(RegisterClinicRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            if (String.IsNullOrEmpty(request.Adress) || String.IsNullOrEmpty(request.CheckPassword) || String.IsNullOrEmpty(request.ClinicName) || String.IsNullOrEmpty(request.Email) || String.IsNullOrEmpty(request.Password))
            {
                return "Lütfen boş alan bırakmayınız!";
            }
            clinic checkUser = db.clinic.Where(p => p.Email.ToLower() == request.Email.ToLower()).SingleOrDefault();
            if (checkUser != null)
            {
                return "Zaten bu epostaya bağlı bir klinik bulunmaktadır. Lütfen başka bir eposta ile deneyiniz!";
            }
            if (request.Password != request.CheckPassword)
            {
                return "Şifreniz eşleşmemektedir.";
            }
            return null;
        }

        public void Delete(int userId)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            clinic user = db.clinic.Where(p => p.Id == userId).SingleOrDefault();
            clinic host = (clinic) HttpContext.Current.Session[SessionKeyManager.LoginKey];
            log log = new log();
            log.AdminId = host.Id;
            log.TargetId = user.Id;
            log.Action = user.Id + " idli kullanıcı " + host.ClinicName + "(" + host.Id +") tarafından silindi";
            db.log.Add(log);
            db.SaveChanges();

            HttpContext.Current.Session[SessionKeyManager.LoginKey] = null;
        }

        public void SetVerify(int clinicId)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            clinic clinic = db.clinic.Where(p => p.Id == clinicId).SingleOrDefault();
            clinic host = (clinic)HttpContext.Current.Session[SessionKeyManager.LoginKey];
            log log = new log();
            log.AdminId = host.Id;
            log.TargetId = clinic.Id;
            if (clinic.Verify == 1)
            {
                log.Action = clinic.Id + " idli kullanıcının onay durumu " + clinic.Verify + "'dan" + 0 + "'e " + host.ClinicName + "(" + host.Id + ") tarafından dönüştürüldü!";
                clinic.Verify = 0;
            }
            else
            {
                log.Action = clinic.Id + " idli kullanıcının onay durumu " + clinic.Verify + "'dan" + 1 + "'e " + host.ClinicName + "(" + host.Id + ") tarafından dönüştürüldü!";
                clinic.Verify = 1;
            }
            db.log.Add(log);
            db.SaveChanges();

            if (clinicId == host.Id)
            {
                HttpContext.Current.Session[SessionKeyManager.LoginKey] = clinic;
            }
        }

        public String RegisterClinic(RegisterClinicRequest request)
        {
            EPetISTEDBEntities db = new EPetISTEDBEntities();
            //Clinic nesnemizi çağırıp doluduruyoruz sonra ise dbye ekliyoruz
            clinic clinic = new clinic();
            clinic.ClinicName = request.ClinicName;
            clinic.Email = request.Email;
            clinic.Password = Utility.EncMD5(request.Password);
            clinic.Adress = request.Adress;
            db.clinic.Add(clinic);
            db.SaveChanges();
            return "Kayıt başarı ile tamamlanmıştır. Lütfen giriş yapınız!";
        }
    }
}