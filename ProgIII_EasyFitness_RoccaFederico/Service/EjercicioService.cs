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
                    tmp.tipo = ddbbdata.getReader()["Tipo"].ToString();
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

        public List<EjercicioModel> getEjerciciosByPersonaID(Int64 _personaID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Ejercicios.id, Ejercicios.nombre, Ejercicios.tipo, Ejercicios.urlEjemplo, Ejercicios.tiempo, Ejercicios.repeticiones, " +
                    "Ejercicios.comentarios, Ejercicios.intensidad " +
                    "from  Entrenadores " +
                    "inner join Ejercicios on Entrenadores.ejercicioId = Ejercicios.id " +
                    "where personaId = '" + _personaID + "'");
                data.sendQuery();
                List<EjercicioModel> aux = new List<EjercicioModel>();

                while(data.getReader().Read())
                {
                    aux.Add(new EjercicioModel(
                        (long)data.getReader()["id"],
                        data.getReader()["nombre"].ToString(),
                        data.getReader()["tipo"].ToString(),
                        data.getReader()["urlEjemplo"].ToString(),
                        (int)data.getReader()["tiempo"],
                        (int)data.getReader()["repeticiones"],
                        data.getReader()["comentarios"].ToString(),
                        (short)data.getReader()["intensidad"])); ;
                }

                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EjercicioModel> getEjerciciosBySearchFromPersonaId(long _id, string _term)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Ejercicios.id, Ejercicios.nombre, Ejercicios.tipo, Ejercicios.urlEjemplo, Ejercicios.tiempo, Ejercicios.repeticiones, " +
                    "Ejercicios.comentarios, Ejercicios.intensidad " +
                    "from Entrenadores " +
                    "inner join Ejercicios on Ejercicios.id = Entrenadores.entrenamientoId " +
                    "where Ejercicios.nombre like LOWER('%" + _term + "%') and Entrenadores.personaId = '" + _id + "'");
                data.sendQuery();
                List<EjercicioModel> aux = new List<EjercicioModel>();

                while (data.getReader().Read())
                {
                    aux.Add(new EjercicioModel(
                        (long)data.getReader()["id"],
                        data.getReader()["nombre"].ToString(),
                        data.getReader()["tipo"].ToString(),
                        data.getReader()["urlEjemplo"].ToString(),
                        (int)data.getReader()["tiempo"],
                        (int)data.getReader()["repeticiones"],
                        data.getReader()["comentarios"].ToString(),
                        (short)data.getReader()["intensidad"])); ;
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