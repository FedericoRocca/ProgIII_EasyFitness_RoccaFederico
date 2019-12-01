using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class EjercicioModel
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string urlEjemplo { get; set; }
        public int tiempo { get; set; }
        public int repeticiones { get; set; }
        public Int16 intensidad { get; set; }
    }
}