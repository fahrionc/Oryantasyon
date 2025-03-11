using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class AdminCarManager : IAdminCarService
    {
        IAdminCarDal _adminCarDal;

        public AdminCarManager(IAdminCarDal adminCarDal)
        {
            _adminCarDal = adminCarDal;
        }

        public void AdminCarAdd(AdminCar adminCar)
        {
            _adminCarDal.Insert(adminCar);
        }

        public void AdminCarDelete(AdminCar adminCar)
        {
            _adminCarDal.Delete(adminCar);
        }

        public void AdminCarUpdate(AdminCar adminCar)
        {
            _adminCarDal.Update(adminCar);
        }

        public AdminCar GetByID(int id)
        {
            return _adminCarDal.Get(x => x.CarID == id);
        }

        public List<AdminCar> GetList()
        {
            return _adminCarDal.List();
        }
    }
}
