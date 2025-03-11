using DataAccessLayer.Concrete.Repositories;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntityFramework
{
    public class EfAdminCarDal : GenericRepository<AdminCar>,IAdminCarDal
    {
    }
}
