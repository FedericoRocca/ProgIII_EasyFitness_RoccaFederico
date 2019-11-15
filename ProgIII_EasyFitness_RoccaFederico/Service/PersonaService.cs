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
                userData.sendQuery();
                personaData.prepareQuery("");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}