using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class EntrenamientoModel
    {
        public Int64 id { get; set; }
        public List<RutinaModel> rutinas { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
    }
}