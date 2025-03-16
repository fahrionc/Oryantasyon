using BusinessLayer.Abstract;
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
    [Authorize]
    public class AdminCarAllController : Controller
    {
        CarManager cm = new CarManager(new EfCarDal());
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
                p.Date = DateTime.Now;
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
        public ActionResult ActiveUsageChart()
        {
            return View();
        }

        public ActionResult IdleTimeChart()
        {
            return View();
        }
        public ActionResult GetActiveWorkTimeData()
        {
            var carvalues = cm.GetList();
            var activeWorkTimeData = carvalues.Select(car => new
            {
                car.CarName,
                ActiveWorkTimePercentage = car.ActiveWorkTime.HasValue ?
                ((car.ActiveWorkTime.Value / (car.ActiveWorkTime.Value + (car.IdleTime ?? 0))) * 100) : 0
            }).ToList();

            return Json(activeWorkTimeData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetIdleTimeData()
        {
            var carvalues = cm.GetList();
            var idleTimeData = carvalues.Select(car => new
            {
                car.CarName,
                IdleTimePercentage = car.IdleTime.HasValue ?
                ((car.IdleTime.Value / (car.ActiveWorkTime.Value + (car.IdleTime ?? 0))) * 100) : 0
            }).ToList();

            return Json(idleTimeData, JsonRequestBehavior.AllowGet);
        }
    }
}