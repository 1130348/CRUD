using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lugares.Models
{
    public class Hashtag
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<POI> POIs { get; set; }
    }
}