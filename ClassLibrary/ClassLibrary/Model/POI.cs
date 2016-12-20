using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lugares.Models
{
    public class POI
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }
    }
}