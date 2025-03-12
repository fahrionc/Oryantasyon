using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    class CarRepository : ICarDal
    {
        Context c = new Context();
        DbSet<Car> _object;
        public void Delete(Car p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetActiveCars()
        {
            throw new NotImplementedException();
        }

        public void Insert(Car p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Car> List()
        {
            return _object.ToList();
        }

        public List<Car> List(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car p)
        {
            c.SaveChanges();
        }
    }
}