using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminCar> AdminCars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
    }
}
