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
                data.prepareQuery("select Personas.dni, Personas.fechaNacimiento, Personas.apellido, Personas.nombre, Usuarios.id, Usuarios.mail, Usuarios.password, Alumnos.id as 'alumnoId', Alumnos.entrenamientoID, Alumnos.personaId, Alumnos.teamID from Usuarios inner join Alumnos on Alumnos.id = Usuarios.id left join Personas on Personas.id = Alumnos.id inner join Entrenamientos on Entrenamientos.id = Alumnos.entrenamientoID inner join Teams on Teams.id = Alumnos.id where Usuarios.mail = '" + _Mail.ToString() + "'");
                data.sendQuery();
                data.getReader().Read();
                AlumnoModel aux = new AlumnoModel();

                if( data.getReader().HasRows )
                {
                    aux.user.id = (Int64)data.getReader()["id"];
                    aux.user.mail = data.getReader()["mail"].ToString();
                    aux.user.password = data.getReader()["password"].ToString();
                    aux.id = (Int64)data.getReader()["alumnoId"];
                    aux.personaId = (Int64)data.getReader()["personaId"];
                    aux.entrenamientos = new List<EntrenamientoModel>();
                    aux.entrenamientos = loadEntrenamientosByPersonId(aux.id);
                    aux.apellido = data.getReader()["apellido"].ToString();
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.dni = (int)data.getReader()["dni"];
                    aux.teams = new List<TeamModel>();
                    aux.teams = loadTeamsByPersonId(aux.id);
                    aux.fechaNacimiento = (DateTime)data.getReader()["fechaNacimiento"];
                    // Calculo de edad
                    aux.edad = (short)Math.Floor((DateTime.Now - aux.fechaNacimiento.Date).TotalDays / 365.25D);
                }


                return aux;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntrenamientoModel> loadEntrenamientosByPersonId(Int64 _personID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("" +
                    "select Entrenamientos.id, Entrenamientos.descripcion, Entrenamientos.idRutina, Entrenamientos.nombre " +
                    "from Entrenamientos inner join Alumnos on Entrenamientos.id = Alumnos.entrenamientoID " +
                    "where Alumnos.personaId = " + _personID + "");
                data.sendQuery();
                List<EntrenamientoModel> auxList = new List<EntrenamientoModel>();

                while (data.getReader().Read())
                {
                    EntrenamientoModel auxReg = new EntrenamientoModel();
                    auxReg.descripcion = data.getReader()["descripcion"].ToString();
                    auxReg.id = (Int64)data.getReader()["id"];
                    auxReg.nombre = data.getReader()["nombre"].ToString();
                    auxList.Add(auxReg);
                }
                return auxList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TeamModel> loadTeamsByPersonId(Int64 _personID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("" +
                    "select Teams.id, Teams.nombre, Teams.descripcion " +
                    "from Teams " +
                    "inner join Alumnos on Teams.id = Alumnos.teamID " +
                    "where Alumnos.personaId =" + _personID + "");

                data.sendQuery();
                List<TeamModel> auxList = new List<TeamModel>();

                while (data.getReader().Read())
                {
                    TeamModel auxReg = new TeamModel();
                    auxReg.descripcion = data.getReader()["descripcion"].ToString();
                    auxReg.id = (Int64)data.getReader()["id"];
                    auxReg.nombre = data.getReader()["nombre"].ToString();
                    auxList.Add(auxReg);
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