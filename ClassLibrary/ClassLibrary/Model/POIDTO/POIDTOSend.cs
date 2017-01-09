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
        public string local { get; set; }
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
            this.local = db.Locals.Find(poi.LocalID).Nome;
            this.categoria = db.Categorias.Find(poi.CategoriaID).nome;
            this.duracaoVisita = poi.duracaoVisita;
            
        }
    }
}
