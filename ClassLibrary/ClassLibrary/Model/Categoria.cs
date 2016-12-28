using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class Categoria
    {
        public int ID { get; set; }
        public string nome { get; set; }

        public virtual ICollection<POI> POIs { get; set; }
    }
}
