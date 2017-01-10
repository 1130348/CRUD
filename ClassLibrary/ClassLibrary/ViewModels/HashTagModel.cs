using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Model;

namespace ClassLibrary.ViewModels
{
    public class HashTagModel
    {
        public int ID { get; set; }
        public string nome { get; set; }

        public List<int> listPois { get; set; }

        public HashTagModel()
        {

        }

        public HashTagModel(Hashtag hash)
        {

            this.ID = hash.ID;
            this.nome = hash.Nome;
            this.listPois = preencheList(hash.POIs);
        }
        public List<int> preencheList(ICollection<POI> listPoi)
        {
            this.listPois = new List<int>();
            foreach(var poi in listPoi)
            {
                this.listPois.Add(poi.PoiID);
            }
            return listPois;
        }

    }


}
