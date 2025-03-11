using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CarAdd(Car car)
        {
            _carDal.Insert(car);
        }

        public void CarDelete(Car car)
        {
            _carDal.Delete(car);
        }

        public void CarUpdate(Car car)
        {
            _carDal.Update(car);
        }

        public Car GetByID(int id)
        {
            return _carDal.Get(x => x.CarID == id);
        }

        public List<Car> GetList()
        {
            return _carDal.List();
        }
    }
}