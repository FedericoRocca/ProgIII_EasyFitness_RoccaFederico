using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class EntrenamientoService
    {
        public List<EntrenamientoModel> getModelByPersonaID(Int64 _ID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("" +
                    "select distinct Entrenamientos.id, Entrenamientos.descripcion, Entrenamientos.nombre " +
                    "from Alumnos " +
                    "left join Entrenamientos on Entrenamientos.id = Alumnos.entrenamientoID " +
                    "where personaId = '" + _ID + "'");
                data.sendQuery();
                List<EntrenamientoModel> aux = new List<EntrenamientoModel>();
                while (data.getReader().Read())
                {
                    if(data.getReader()["id"] != DBNull.Value)
                    {
                        aux.Add(new EntrenamientoModel(
                        (Int64)data.getReader()["id"],
                        data.getReader()["descripcion"].ToString(),
                        data.getReader()["nombre"].ToString())
                        );
                    }
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