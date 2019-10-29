using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class AlumnoService
    {
        public AlumnoModel getAlumnoByID(Int64 _ID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Alumnos where ID = '" + _ID + "'");
                data.sendQuery();
                data.getReader().Read();
                AlumnoModel aux = new AlumnoModel();
                aux.apellido = data.getReader()["Apellido"].ToString();
                aux.dni = (int)data.getReader()["DNI"];
                aux.edad = (short)data.getReader()["Edad"];
                aux.entrenamientos = (List<EntrenamientoModel>)data.getReader()["Entrenamientos"];
                aux.id = (Int64)data.getReader()["ID"];
                aux.nombre = data.getReader()["Nombre"].ToString();
                aux.teams = (List<TeamModel>)data.getReader()["Teams"];

                return aux;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AlumnoModel getAlumnoByUsrMail(string _Mail)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(  "select Usuarios.id, Usuarios.mail, Usuarios.password, Alumnos.id as 'alumnoId', " +
                                    "Alumnos.entrenamientoID, Alumnos.personaId, Alumnos.teamID from Usuarios inner join Alumnos " +
                                    "on Alumnos.id = Usuarios.id where Usuarios.mail = " + _Mail + "");
                data.sendQuery();
                data.getReader().Read();
                AlumnoModel aux = new AlumnoModel();

                aux.user.id = (Int64)data.getReader()["id"];
                aux.user.mail = data.getReader()["mail"].ToString();
                aux.user.password = data.getReader()["password"].ToString();
                aux.id = (Int64)data.getReader()["alumnoId"];
                aux.entrenamientos = new List<EntrenamientoModel>();
                aux.entrenamientos.Add((EntrenamientoModel)data.getReader()["entrenamientoID"]);
                aux.personaId = (Int64)data.getReader()["personaId"];
                aux.teams = new List<TeamModel>();
                aux.teams.Add((TeamModel)data.getReader()["teamID"]);
                
                return aux;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}