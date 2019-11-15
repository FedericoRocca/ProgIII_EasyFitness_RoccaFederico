using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataGateway;
using ProgIII_EasyFitness_RoccaFederico.Models;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class PersonaService
    {
        public bool DNIExists(int _DNI)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Personas where dni = '" + _DNI + "';");
                if (data.sendScalarQuery() <= 0)
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

        public void altaPersona( PersonaModel _Persona )
        {
            try
            {
                DDBBGateway userData = new DDBBGateway();
                DDBBGateway personaData = new DDBBGateway();
                userData.prepareQuery("insert into Usuarios values('" + _Persona.user.mail + "', '" + _Persona.user.password + "');");
                userData.sendStatement();
                if(userData.getAffectedRows() <= 0)
                {
                    throw new Exception("Error al dar de alta usuario en base de datos");
                }
                DDBBGateway userQueryID = new DDBBGateway();
                userQueryID.prepareQuery("select top 1 id from Usuarios order by id DESC");
                userQueryID.sendQuery();
                int userId = (int)userQueryID.getReader()["id"] + 1;
                personaData.prepareQuery("insert into Personas values ('" +  _Persona.nombre + "', " +
                    "'" + _Persona.apellido + "', '" + _Persona.dni + "', '1998-01-02 00:00:00.000', '" + userId + "')");
                personaData.sendQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}