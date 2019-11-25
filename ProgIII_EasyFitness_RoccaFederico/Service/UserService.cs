using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataGateway;
using ProgIII_EasyFitness_RoccaFederico.Models;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class userService
    {
        public void newUsuario( usuarioModel user )
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "insert into Usuarios values (" +
                    "'" + user.idPersona + "', '" + user.mail + "', '" + user.password + "', '" + user.profile + "')");
                data.sendStatement();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}