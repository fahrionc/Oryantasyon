using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using FluentValidation.Results;


namespace Oryantasyon.Controllers
{
    public class CarController : Controller
    {
        CarManager cm = new CarManager(new EfCarDal());
        public ActionResult GetCarList()
        {
            var carvalues = cm.GetList();
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
            //cm.CarAdd(p);
            CarValidatior carValidatior = new CarValidatior();
            ValidationResult results = carValidatior.Validate(p);
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
    }
}