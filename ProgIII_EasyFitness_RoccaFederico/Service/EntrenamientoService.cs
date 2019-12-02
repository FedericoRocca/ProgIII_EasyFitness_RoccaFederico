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
        public bool newEntrenamiento(EntrenamientoModel _entrenamiento)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "insert into Entrenamientos " +
                    "values ('" + _entrenamiento.idPersona + "', '" + _entrenamiento.descripcion + "', '" + _entrenamiento.nombre + "')");
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

        public List<EntrenamientoModel> getEntrenamientosByPersonaID(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Entrenamientos where idPersona = '" +persona.id + "'");
                data.sendQuery();
                EntrenamientoModel aux = new EntrenamientoModel();
                List<EntrenamientoModel> auxList = new List<EntrenamientoModel>();
                while( data.getReader().Read() )
                {
                    aux.descripcion = data.getReader()["descripcion"].ToString();
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    auxList.Add(aux);
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