using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminCar
    {
        [Key]
        public int CarID { get; set; }
        [StringLength(50)]
        public string CarName { get; set; }
        [StringLength(30)]
        public string CarPlate { get; set; }

        // Navigation Property
        public ICollection<UserCar> UserCars { get; set; }
    }

}
