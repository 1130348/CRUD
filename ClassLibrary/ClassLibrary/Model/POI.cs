using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClassLibrary.Model
{
    public class POI
    {
        public int PoiID { get; set; }
        [Required(ErrorMessage = "No Name was chosen.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }
        public Categorias Categoria { get; set; }
        //[ForeignKey("Categoria")]
        //public int CategoriaID { get; set; }
        //public virtual Categoria Categoria { get; set; }
        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //[Editable(false)]
        //public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Percurso> Percursos { get; set; }
    }

    public enum Categorias
    {
        Restauração,
        Cultura,
        Diversão,
        Outros
    }

}