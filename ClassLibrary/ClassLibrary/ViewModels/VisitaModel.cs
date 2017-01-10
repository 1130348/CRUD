using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Model;

namespace ClassLibrary.ViewModels
{
    public class VisitaModel
    {
        public int idVisita { get; set; }
        public string data { get; set; }
        public string descrição { get; set; }
        public string horaInicio { get; set; }
        public int idPercurso { get; set; }
        public int idUser { get; set; }

        public VisitaModel(){   }
        public VisitaModel(Visita visita)
        {
            this.idVisita = idVisita;
            this.data = data;
            this.descrição = descrição;
            this.horaInicio = horaInicio;
            this.idPercurso = idPercurso;
            this.idUser = idUser;

        }

        

    }
}
