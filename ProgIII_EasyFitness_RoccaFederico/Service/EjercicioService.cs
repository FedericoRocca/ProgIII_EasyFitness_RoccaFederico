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
        public bool newEjercicio(EjercicioModel _ejercicio)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                //data.prepareQuery(
                //    "insert into Ejercicios " +
                //    "values ('" + _ejercicio.nombre + "', '" + _ejercicio.tipo + "', '" + _ejercicio.urlEjemplo + 
                //    "', '" + _ejercicio.tiempo + "', '" + _ejercicio.repeticiones + "', '" + _ejercicio.comentarios + "', '" + _ejercicio.intensidad +
                //    "', '" + _ejercicio. + "', 'idRutina')");
                data.sendStatement();
                if (data.getAffectedRows() <= 0)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EjercicioModel> getEjerciciosByPersonaID(personaModel _persona)
        {
            try
            {
                List<EjercicioModel> auxList = new List<EjercicioModel>();
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Ejercicios.id, Ejercicios.idPersona, Ejercicios.idRutina, Ejercicios.nombre, " +
                    "Ejercicios.tipo, Ejercicios.urlEjemplo, Ejercicios.tiempo, Ejercicios.repeticiones, Ejercicios.comentarios, Ejercicios.intensidad " +
                    "from Ejercicios " +
                    "inner join Personas on Personas.id = Ejercicios.idPersona " +
                    "where Personas.id = '" + _persona.id + "'");
                data.sendQuery();
                while (data.getReader().Read() )
                {
                    EjercicioModel aux = new EjercicioModel();
                    aux.id = long.Parse(data.getReader()["id"].ToString());
                    aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    aux.idRutina = long.Parse(data.getReader()["idRutina"].ToString());
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.tipo = data.getReader()["tipo"].ToString();
                    aux.urlEjemplo = data.getReader()["urlEjemplo"].ToString();
                    aux.tiempo = int.Parse(data.getReader()["tiempo"].ToString());
                    aux.repeticiones = int.Parse(data.getReader()["repeticiones"].ToString());
                    aux.comentarios = data.getReader()["comentarios"].ToString();
                    aux.intensidad = Int16.Parse(data.getReader()["intensidad"].ToString());
                    auxList.Add( aux );
                }
                return auxList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}