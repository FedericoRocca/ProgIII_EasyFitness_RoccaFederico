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
    }
}