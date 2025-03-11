using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class UserCarManager : IUserCarService
    {
        IUserCarDal _userCarDal;

        public UserCarManager(IUserCarDal userCarDal)
        {
            _userCarDal = userCarDal;
        }

        public UserCar GetByID(int id)
        {
            return _userCarDal.Get(x => x.UserCarID == id);
        }

        public List<UserCar> GetList()
        {
            return _userCarDal.List();
        }

        public void UserCarAdd(UserCar userCar)
        {
            _userCarDal.Insert(userCar);
        }

        public void UserCarDelete(UserCar userCar)
        {
            _userCarDal.Delete(userCar);
        }

        public void UserCarUpdate(UserCar userCar)
        {
            _userCarDal.Update(userCar);
        }
    }
}
