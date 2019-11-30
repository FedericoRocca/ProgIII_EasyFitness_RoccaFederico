using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class personaModel
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public DateTime fechaNacimiento { get; set; }
        public usuarioModel user { get; set; }
        public personaModel()
        {
            if(user == null)
            {
                user = new usuarioModel();
            }
        }
    }
}