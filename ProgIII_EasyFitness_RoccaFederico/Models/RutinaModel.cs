using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class RutinaModel
    {
        public long id { get; set; }
        public long idPersona { get; set; }
        public long idEntrenamiento { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public List<EjercicioModel> ejercicios { get; set; }
    }
}