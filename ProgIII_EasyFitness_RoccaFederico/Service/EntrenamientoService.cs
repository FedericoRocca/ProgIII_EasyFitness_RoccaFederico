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

        public bool updateEntrenamiento(EntrenamientoModel _entrenamiento)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "update Entrenamientos" +
                    " set descripcion = '" + _entrenamiento.descripcion + "', nombre = '" + _entrenamiento.nombre + "' " +
                    "where id = '" + _entrenamiento.id + "'");
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
                List<EntrenamientoModel> auxList = new List<EntrenamientoModel>();
                while( data.getReader().Read() )
                {
                    EntrenamientoModel aux = new EntrenamientoModel();
                    aux.descripcion = data.getReader()["descripcion"].ToString();
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    aux.id = long.Parse(data.getReader()["id"].ToString());
                    auxList.Add(aux);
                }
                return auxList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntrenamientoModel getEntrenamientoByPersonaID(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Entrenamientos where idPersona = '" + persona.id + "'");
                data.sendQuery();
                data.getReader().Read();
                EntrenamientoModel aux = new EntrenamientoModel();
                aux.descripcion = data.getReader()["descripcion"].ToString();
                aux.nombre = data.getReader()["nombre"].ToString();
                aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                aux.id = long.Parse(data.getReader()["id"].ToString());
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}