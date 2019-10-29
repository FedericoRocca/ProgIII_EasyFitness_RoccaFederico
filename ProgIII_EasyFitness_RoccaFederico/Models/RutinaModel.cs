using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class RutinaModel
    {
        public Int64 id { get; set; }
        public List<EjercicioModel> ejercicios { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
    }
}