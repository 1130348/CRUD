using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Model;

namespace ClassLibrary.ViewModels
{
    public class PercursoModel
    {
        public int percursoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<int> listPois { get; set; }


        public PercursoModel()
        {
        }

        public PercursoModel(Percurso percurso)
        {
            this.percursoID = percurso.PercursoID;
            this.Nome = percurso.Nome;
            this.Descricao = percurso.Descricao;
            this.listPois = preencheList(percurso.POIs);
        }

        public List<int> preencheList(ICollection<POI> listPoi)
        {
            this.listPois = new List<int>();
            foreach (var poi in listPoi)
            {
                this.listPois.Add(poi.PoiID);
            }
            return listPois;
        }

    }
}
