using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class UsuarioModel : PersonaModel
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}