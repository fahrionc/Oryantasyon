using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oryantasyon.Controllers
{
    public class UserCarController : Controller
    {
        // GET: UserCar
        UserCarManager ucm = new UserCarManager(new EfUserCarDal());
        AdminCarManager acm = new AdminCarManager(new EfAdminCarDal());
        public ActionResult UserCarGetList()
        {
            var carvalues = ucm.GetList();
            return View(carvalues);
        }

        [HttpGet]
        public ActionResult UserAddCar()
        {
            List<AdminCar> adminCars = acm.GetList();
            ViewBag.AdminCars = new SelectList(adminCars, "CarID", "CarName");
            return View();
        }
        [HttpPost]
        public ActionResult UserAddCar(UserCar p)
        {
            UserCarValidator userCarValidator = new UserCarValidator();
            ValidationResult result = userCarValidator.Validate(p);

            List<AdminCar> adminCars = acm.GetList();
            ViewBag.AdminCars = new SelectList(adminCars, "CarID", "CarName");

            if (result.IsValid)
            {
                var existingAdminCar = acm.GetByID(p.CarID);
                if (existingAdminCar == null)
                {
                    ModelState.AddModelError("CarID", "Geçerli bir araç seçmelisiniz.");
                    return View();
                }
                else
                {
                    ucm.UserCarAdd(p);
                    return RedirectToAction("UserCarGetList");
                }
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        public ActionResult UserCarDelete(int id)
        {
            var carvalue = ucm.GetByID(id);
            if(carvalue != null)
            {
                ucm.UserCarDelete(carvalue);
            }
            return RedirectToAction("UserCarGetList");
        }
        [HttpGet]
        public ActionResult UserCarEdit(int id)
        {
            var carvalues = ucm.GetByID(id);
            if (carvalues == null)
            {
                return HttpNotFound();
            }

            List<AdminCar> adminCars = acm.GetList();
            ViewBag.AdminCars = new SelectList(adminCars, "CarID", "CarName", carvalues.CarID);

            return View(carvalues);
        }
        [HttpPost]
        public ActionResult UserCarEdit(UserCar p)
        {
            UserCarValidator userCarValidator = new UserCarValidator();
            ValidationResult result = userCarValidator.Validate(p);

            if (result.IsValid)
            {
                ucm.UserCarUpdate(p);
                return RedirectToAction("UserCarGetList");
            }
            List<AdminCar> adminCars = acm.GetList();
            ViewBag.AdminCars = new SelectList(adminCars, "CarID", "CarName", p.CarID);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(p);
        }
    }
}