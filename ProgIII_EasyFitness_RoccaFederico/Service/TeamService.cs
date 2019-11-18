using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class TeamService
    {
        public List<TeamModel> getTeamsByPersonaID(Int64 _ID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select distinct Teams.id, Teams.descripcion, Teams.nombre " +
                    "from Alumnos " +
                    "left join Teams on Alumnos.teamID = Teams.id where " +
                    "Alumnos.personaId = '" + _ID + "'");
                data.sendQuery();
                List<TeamModel> aux = new List<TeamModel>();
                while (data.getReader().Read() )
                {
                    if(data.getReader()["id"] != DBNull.Value)
                    {
                        aux.Add(new TeamModel(
                        (Int64)data.getReader()["id"],
                        data.getReader()["nombre"].ToString(),
                        data.getReader()["descripcion"].ToString()));
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