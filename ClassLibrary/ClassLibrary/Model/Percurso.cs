using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class Percurso
    {
        public int PercursoID { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public virtual ICollection<POI> POIs { get; set; }
    }
}
