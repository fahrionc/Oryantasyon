using DataAccessLayer.Concrete.Repositories;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntityFramework
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        Context context = new Context();
        public List<Car> GetActiveCars()
        {
            var cars = context.Cars
                .AsNoTracking()
                .Where(x => x.IsActive == true).ToList();

            return cars;
        }
    }
}
