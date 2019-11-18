using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class TeamModel
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TeamModel(){}
        public TeamModel(Int64 _ID, string _nombre, string _descripcion)
        {
            id = _ID;
            nombre = _nombre;
            descripcion = _descripcion;
        }
    }
}