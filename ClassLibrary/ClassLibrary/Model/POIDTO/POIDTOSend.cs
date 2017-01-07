using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class POIDTOSend : POIDTO
    {
        public virtual Local local { get; set; }
        public virtual Categoria categoria { get; set; }
        //public string Username;

        public POIDTOSend(POI poi)
        {
            this.PoiID = poi.PoiID;
            this.Nome = poi.Nome;
            this.Descricao = poi.Descricao;
            this.local = poi.Local;
            this.categoria = poi.Categoria;
            //this.Username = poi.User.Username;
        }
    }
}
