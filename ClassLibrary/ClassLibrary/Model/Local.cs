using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lugares.Models
{
    public class Local
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<POI> Pois { get; set; }
    }
}