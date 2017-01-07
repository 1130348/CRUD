using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Model
{
    public class SugerirPOI
    {
        [Key]
        public int PoiID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int duracaoVisita { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Percurso> Percursos { get; set; }
        public int UserID { get; set; }
    }
}
