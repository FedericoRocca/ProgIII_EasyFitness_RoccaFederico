using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgIII_EasyFitness_RoccaFederico.Controllers

namespace Service
{
    class EjercicioService
    {
        public List<Ejercicio> getEjercicios()
        {
            try
            {
                DDBBGateway ddbbdata = new DDBBGateway();
                List<Ejercicio> aux = new List<Ejercicio>();
                ddbbdata.prepareQuery("select ID, Nombre, Tipo, UrlEjemplo, Tiempo, Repeticiones, Comentarios from Ejercicios");
                ddbbdata.sendQuery();
                while (ddbbdata.getReader().Read())
                {
                    Ejercicio tmp = new Ejercicio();
                    tmp.id = (Int64)ddbbdata.getReader()["ID"];
                    tmp.nombre = ddbbdata.getReader()["Nombre"].ToString();
                    tmp.tipo = (int)ddbbdata.getReader()["Tipo"];
                    tmp.urlEjemplo = ddbbdata.getReader()["UrlEjemplo"].ToString();
                    if (!Convert.IsDBNull(ddbbdata.getReader()["Tiempo"]))
                    {
                        tmp.tiempo = (int)ddbbdata.getReader()["Tiempo"];
                    }
                    if (!Convert.IsDBNull(ddbbdata.getReader()["Repeticiones"]))
                    {
                        tmp.repeticiones = (int)ddbbdata.getReader()["Repeticiones"];
                    }
                    tmp.comentarios = ddbbdata.getReader()["Comentarios"].ToString();

                    aux.Add(tmp);
                }

                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
