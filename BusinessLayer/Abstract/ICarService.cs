using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarService
    {
        List<Car> GetList();
        void CarAdd(Car car);
        Car GetByID(int id);
        void CarDelete(Car car);
        void CarUpdate(Car car);
    }
}
