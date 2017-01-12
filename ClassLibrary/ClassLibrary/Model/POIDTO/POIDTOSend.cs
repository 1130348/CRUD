using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAL;

namespace ClassLibrary.Model
{
    public class POIDTOSend : POIDTO
    {
        public int LocalID { get; set; }
        public string categoria { get; set; }

        public POIDTOSend()
        {

        }
        public POIDTOSend(POI poi)
        {
            this.PoiID = poi.PoiID;
            this.Nome = poi.Nome;
            this.Descricao = poi.Descricao;
            DatumContext db = new DatumContext();
            this.LocalID = db.Locals.Find(poi.LocalID).LocalID;
            this.categoria = db.Categorias.Find(poi.CategoriaID).nome;
            this.duracaoVisita = poi.duracaoVisita;
            
        }
    }
}
