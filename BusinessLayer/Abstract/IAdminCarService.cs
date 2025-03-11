using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminCarService
    {
        List<AdminCar> GetList();
        AdminCar GetByID(int id);
        void AdminCarAdd(AdminCar adminCar);
        void AdminCarDelete(AdminCar adminCar);
        void AdminCarUpdate(AdminCar adminCar);
    }
}
