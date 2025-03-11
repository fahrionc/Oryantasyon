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
    public class AdminCarController : Controller
    {
        AdminCarManager acm = new AdminCarManager(new EfAdminCarDal());
        public ActionResult GetCarList()
        {
            var carvalues = acm.GetList();
            return View(carvalues);
        }

        [HttpGet]
        public ActionResult AdminAddCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAddCar(AdminCar p)
        {
            AdminCarValidator adminCarValidator = new AdminCarValidator();
            ValidationResult results = adminCarValidator.Validate(p);
            if (results.IsValid)
            {
                acm.AdminCarAdd(p);
                return RedirectToAction("GetCarList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult AdminDeleteCar(int id)
        {
            var adminCarValue = acm.GetByID(id);
            acm.AdminCarDelete(adminCarValue);
            return RedirectToAction("GetCarList");
        }

        [HttpGet]
        public ActionResult AdminEditCar(int id)
        {
            var adminCarValue = acm.GetByID(id);
            return View(adminCarValue);
        }
        [HttpPost]
        public ActionResult AdminEditCar(AdminCar p)
        {
            acm.AdminCarAdd(p);
            return RedirectToAction("GetCarList");
        }
    }
}