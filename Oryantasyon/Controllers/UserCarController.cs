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
        CarManager carmanager = new CarManager(new EfCarDal());

        public ActionResult UserCarGetList()
        {
            var carvalues = carmanager.GetList();
            return View(carvalues);
        }

        [HttpGet]
        public ActionResult UserCarEdit(int id)
        {
            var carvalues = carmanager.GetByID(id);
            return View(carvalues);
        }
        [HttpPost]
        public ActionResult UserCarEdit(Car p)
        {
            p.IsActive = true;
            carmanager.CarUpdate(p);
            return RedirectToAction("UserCarGetList");
        }
        public ActionResult UserActiveUsageChart()
        {
            return View();
        }

        public ActionResult UserIdleTimeChart()
        {
            return View();
        }
        public ActionResult GetActiveWorkTimeData()
        {
            var carvalues = carmanager.GetList();
            var activeWorkTimeData = carvalues.Select(car => new
            {
                car.CarName,
                ActiveWorkTimePercentage = car.ActiveWorkTime.HasValue ?
                ((car.ActiveWorkTime.Value / (car.ActiveWorkTime.Value + (car.IdleTime ?? 0))) * 100) : 0
            }).ToList();

            return Json(activeWorkTimeData, JsonRequestBehavior.AllowGet);
        }

        // Bu aksiyon, boşta bekleme süresinin yüzdesini hesaplar
        public ActionResult GetIdleTimeData()
        {
            var carvalues = carmanager.GetList();
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