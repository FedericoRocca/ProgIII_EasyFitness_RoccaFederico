using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class UserService
    {
        public bool validateUserLogin(UsuarioModel user)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Users where Mail = '" + user.mail + "' and Password = '" + user.password + "'");
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
    }
}