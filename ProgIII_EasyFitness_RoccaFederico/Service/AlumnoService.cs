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

        public List<EntrenamientoModel> getEntrenamientosByAluID(Int64? _aluID)
        {
            try
            {
                List<EntrenamientoModel> tmp = new List<EntrenamientoModel>();
                DDBBGateway data = new DDBBGateway();

                data.prepareQuery(
                    "select Entrenamientos.id, Entrenamientos.descripcion, Entrenamientos.nombre " +
                    "from Alumnos " +
                    "left join Entrenamientos on Alumnos.entrenamientoID = Entrenamientos.id " +
                    "where Alumnos.personaId = '" + _aluID + "'");
                data.sendQuery();
                while (data.getReader().Read())
                {
                    tmp.Add(new EntrenamientoModel(
                        (Int64)data.getReader()["id"],
                        data.getReader()["descripcion"].ToString(),
                        data.getReader()["nombre"].ToString())
                        );
                }
                return tmp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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
                data.prepareQuery(
                    "select Personas.id as 'PersonaID', Personas.nombre, Personas.apellido, Personas.dni, Personas.fechaNacimiento, " +
                    "Personas.userID as 'userID', Usuarios.mail, Usuarios.password, Alumnos.personaId as 'aluID' " +
                    "from Personas " +
                    "inner join Usuarios on Personas.userID = Usuarios.id " +
                    "left join Alumnos on Personas.id = Alumnos.personaId " +
                    "where Usuarios.mail = '" + _Mail + "';");
                data.sendQuery();
                data.getReader().Read();
                AlumnoModel aux = new AlumnoModel();

                if (data.getReader().HasRows)
                {

                    aux.personaId = (Int64)data.getReader()["PersonaID"];
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.apellido = data.getReader()["apellido"].ToString();
                    aux.dni = (int)data.getReader()["dni"];
                    aux.fechaNacimiento = DateTime.Parse(data.getReader()["fechaNacimiento"].ToString());
                    aux.user.id = (Int64)data.getReader()["userID"];
                    aux.user.mail = data.getReader()["mail"].ToString();
                    aux.user.password = data.getReader()["password"].ToString();
                    aux.edad = (short)Math.Floor((DateTime.Now - aux.fechaNacimiento.Date).TotalDays / 365.25D);

                    EntrenamientoService eServ = new EntrenamientoService();
                    aux.entrenamientos = eServ.getModelByPersonaID( aux.personaId );

                    TeamService tServ = new TeamService();
                    aux.teams = tServ.getTeamsByPersonaID( aux.personaId );
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