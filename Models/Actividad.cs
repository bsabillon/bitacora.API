using System;

namespace bitacora.API.Models{
    public class Actividad {
        public int id { get; set; }

        public string titulo {get;set;}
        public string descripcion {get;set;}
        public DateTime  horaInicio { get; set; }
        public DateTime horaFinal { get; set; }
        public Category Category {get;set;}

    }
}