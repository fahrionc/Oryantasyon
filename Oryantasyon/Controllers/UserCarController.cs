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
        public ActionResult UserCarGetList()
        {
            var carvalues = ucm.GetList();
            return View(carvalues);
        }

        [HttpGet]
        public ActionResult UserAddCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserAddCar(UserCar p)
        {
            UserCarValidator userCarValidator = new UserCarValidator();
            ValidationResult result = userCarValidator.Validate(p);
            if (result.IsValid)
            {
                ucm.UserCarAdd(p);
                return RedirectToAction("UserCarGetList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
                return View();
        }
        public ActionResult UserCarDelete(int id)
        {
            var carvalue = ucm.GetByID(id);
            ucm.UserCarDelete(carvalue);
            return RedirectToAction("UserCarGetList");
        }
        [HttpGet]
        public ActionResult UserCarEdit(int id)
        {
            var carvalues = ucm.GetByID(id);
            return View(carvalues);
        }
        [HttpPost]
        public ActionResult UserCarEdit(UserCar p)
        {
            ucm.UserCarUpdate(p);
            return RedirectToAction("UserCarGetList");
        }
    }
}