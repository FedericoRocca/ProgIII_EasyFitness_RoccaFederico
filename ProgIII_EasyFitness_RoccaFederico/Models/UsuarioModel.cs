using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class usuarioModel
    {
        public long id { get; set; }
        public long idPersona { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string profile { get; set; }
        public usuarioModel(){}
    }
}