using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        [StringLength(50)]
        public string CarName { get; set; } // Nullable olur çünkü [Required] yok

        [StringLength(30)]
        public string CarPlate { get; set; } // Nullable olur


        public double? ActiveWorkTime { get; set; } // Nullable
        public double? MaintenanceTime { get; set; } // Nullable
        public double? IdleTime { get; set; } // Nullable
        public bool IsActive { get; set; }


    }

}
