using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary.Model
{
    public class POI
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }
    }
}