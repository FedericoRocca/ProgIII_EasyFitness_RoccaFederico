using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class EjercicioService
    {
        public List<EjercicioModel> getEjercicios()
        {
            try
            {
                DDBBGateway ddbbdata = new DDBBGateway();
                List<EjercicioModel> aux = new List<EjercicioModel>();
                ddbbdata.prepareQuery("select ID, Nombre, Tipo, UrlEjemplo, Tiempo, Repeticiones, Comentarios from Ejercicios");
                ddbbdata.sendQuery();
                while (ddbbdata.getReader().Read())
                {
                    EjercicioModel tmp = new EjercicioModel();
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