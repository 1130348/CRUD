using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassLibrary.Model
{
    public class Local
    {
        public int LocalID { get; set; }
        [Required(ErrorMessage = "No Name was chosen.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "No Latitude value was chosen."), Display(Name = "Latitude"), Range(-90, 90)]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "No Longitude was chosen."), Display(Name = "Longitude"), Range(-180, 180)]
        public double Longitude { get; set; }

        public virtual ICollection<POI> Pois { get; set; }
    }
}