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
    public class AdminCarAllController : Controller
    {
        CarManager cm = new CarManager(new EfCarDal());
        [Authorize]
        public ActionResult Index()
        {
            var carvalues = cm.GetList();
            return View(carvalues);
        }

        public ActionResult GetCarList()
        {
            var carvalues = cm.GetActiveList();
            return View(carvalues);
        }

        [HttpGet]
        public ActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCar(Car p)
        {
            CarValidatior carValidator = new CarValidatior();
            ValidationResult results = carValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CarAdd(p);
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
        public ActionResult DeleteCar(int id)
        {
            var carvalue = cm.GetByID(id);
            cm.CarDelete(carvalue);
            return RedirectToAction("GetCarList");
        }

        [HttpGet]
        public ActionResult EditCar(int id)
        {
            var carvalues = cm.GetByID(id);
            return View(carvalues);
        }
        [HttpPost]
        public ActionResult EditCar(Car p)
        {
            p.IsActive = true;
            cm.CarUpdate(p);
            return RedirectToAction("GetCarList");
        }
    }
}