using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class EntrenamientoModel
    {
        public long id { get; set; }
        public long idPersona { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public List<RutinaModel> rutinas { get; set; }
    }
}