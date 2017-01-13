using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Model
{
    public class Visita
    {
        [Key]
        public int idVisita { get; set; }
        public string data { get; set; }
        public string descrição { get; set; }
        public string horaInicio { get; set;}
        public int idPercurso { get; set;}
        public int idUser { get; set; }
        public string userEmail { get; set; }
    }
}
