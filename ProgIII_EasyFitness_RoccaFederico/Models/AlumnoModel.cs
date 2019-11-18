using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using ProgIII_EasyFitness_RoccaFederico.Service;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class AlumnoModel : PersonaModel
    {
        public Int64? id { get; set; }
        public Int64 personaId { get; set; }
        public List<EntrenamientoModel> entrenamientos { get; set; }
        public List<TeamModel> teams { get; set; }

        public AlumnoModel()
        {
            user = new UsuarioModel();
            entrenamientos = new List<EntrenamientoModel>();
            teams = new List<TeamModel>();
        }

    }
}