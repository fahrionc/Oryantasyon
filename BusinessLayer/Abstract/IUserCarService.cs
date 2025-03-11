using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserCarService
    {
        List<UserCar> GetList();
        void UserCarAdd(UserCar userCar);
        void UserCarDelete(UserCar userCar);
        void UserCarUpdate(UserCar userCar);
        UserCar GetByID(int id);
    }
}
