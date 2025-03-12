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


    }
}