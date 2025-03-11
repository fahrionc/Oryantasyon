using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserCar
    {
        [Key]
        public int UserCarID { get; set; }
        public double ActiveWorkTime { get; set; }
        public double MaintenanceTime { get; set; }
        public double IdleTime { get; set; }
    }
}
