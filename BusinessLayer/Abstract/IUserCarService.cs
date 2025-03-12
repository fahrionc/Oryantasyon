using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IUserCarService
    {
        List<UserCar> GetList();
        void UserCarAdd(UserCar userCar);
        void UserCarDelete(UserCar userCar);
        void UserCarUpdate(UserCar userCar);
        UserCar GetByID(int id);
        List<UserCar> GetByCarID(int carID); // Belirli bir araca ait kullanıcı verilerini getir
    }
}
