using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class EntrenadorModel : PersonaModel
    {
        public Int64 id { get; set; }
        public List<EntrenamientoModel> entrenamientos { get; set; }
        public List<RutinaModel> rutinas { get; set; }
        public List<EjercicioModel> ejercicios { get; set; }
        public List<TeamModel> teams { get; set; }
    }
}