using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class PersonaModel
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public Int16 edad { get; set; }
    }
}