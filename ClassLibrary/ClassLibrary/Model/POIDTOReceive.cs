using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class POIDTOReceive : POIDTO
    {
        [ForeignKey("Local")]
        public int LocalID { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public POIDTOReceive(POI poi)
        {
            this.PoiID = poi.PoiID;
            this.Nome = poi.Nome;
            this.Descricao = poi.Descricao;
            this.LocalID = poi.LocalID;
            //this.CategoriaID = poi.CategoriaID;
        }
    }
}
