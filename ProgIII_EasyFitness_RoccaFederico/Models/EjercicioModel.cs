using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgIII_EasyFitness_RoccaFederico.Models
{
    public class EjercicioModel
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public int tipo { get; set; }
        public string urlEjemplo { get; set; }
        public int? tiempo { get; set; }
        public int? repeticiones { get; set; }
        public string comentarios { get; set; }
        public short intensidad { get; set; }

        public EjercicioModel(
            Int64 _id, 
            string _nombre,
            int _tipo, 
            string _urlEjemplo, 
            int? _tiempo, 
            int? _repeticiones,
            string _comentarios,
            short _intensidad)
        {
            id = _id;
            nombre = _nombre;
            tipo = _tipo;
            urlEjemplo = _urlEjemplo;
            if (_tiempo != null)
            {
                tiempo = _tiempo;
            }
            if (_repeticiones != null)
            {
                repeticiones = _repeticiones;
            }
            comentarios = _comentarios;
            intensidad = _intensidad;
        }

        public EjercicioModel(){}
    }
}