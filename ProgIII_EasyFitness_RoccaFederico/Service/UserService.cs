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

        public bool updateUsuarioByID(usuarioModel _user)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "update Usuarios " +
                    "set mail = '" + _user.mail + "', password = '" + _user.password + "', profile = '" + _user.profile + "' " +
                    "where id = '" + _user.id + "'");
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