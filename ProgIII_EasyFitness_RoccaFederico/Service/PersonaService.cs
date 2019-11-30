using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class personaService
    {

        public personaModel getPersonaByMailAndDNI(string Mail, int DNI)
        {
            try
            {
                personaModel persona = new personaModel();

                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Personas.id as personaID, Personas.nombre, Personas.apellido, Personas.fechaNacimiento, " +
                    "Usuarios.id as usuarioID, Usuarios.idPersona, Usuarios.mail, Usuarios.password, Usuarios.profile " +
                    "from Personas " +
                    "inner join Usuarios on Personas.id = Usuarios.idPersona " +
                    "where Personas.dni = '" + DNI + "' and Usuarios.mail = '" + Mail + "'");
                data.sendQuery();
                data.getReader().Read();
                persona.id = long.Parse(data.getReader()["personaID"].ToString());
                persona.nombre = data.getReader()["nombre"].ToString();
                persona.apellido = data.getReader()["apellido"].ToString();
                persona.fechaNacimiento = DateTime.Parse(data.getReader()["fechaNacimiento"].ToString());
                persona.user.id = long.Parse(data.getReader()["usuarioID"].ToString());
                persona.user.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                persona.user.mail = data.getReader()["mail"].ToString();
                persona.user.password = data.getReader()["password"].ToString();
                persona.user.profile = data.getReader()["profile"].ToString();

                return persona;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public personaModel getPersonaByMailAndPassword(string Mail, string password)
        {
            try
            {
                personaModel persona = new personaModel();

                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Personas.id as personaID, Personas.nombre, Personas.apellido, Personas.dni, Personas.fechaNacimiento, " +
                    "Usuarios.id as usuarioID, Usuarios.idPersona, Usuarios.mail, Usuarios.password, Usuarios.profile " +
                    "from Personas " +
                    "inner join Usuarios on Personas.id = Usuarios.idPersona " +
                    "where Usuarios.password = '" + password + "' and Usuarios.mail = '" + Mail + "'");
                data.sendQuery();
                if(data.getReader().Read())
                {
                    persona.id = long.Parse(data.getReader()["personaID"].ToString());
                    persona.nombre = data.getReader()["nombre"].ToString();
                    persona.apellido = data.getReader()["apellido"].ToString();
                    persona.dni = int.Parse(data.getReader()["dni"].ToString());
                    persona.fechaNacimiento = DateTime.Parse(data.getReader()["fechaNacimiento"].ToString());
                    persona.user.id = long.Parse(data.getReader()["usuarioID"].ToString());
                    persona.user.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    persona.user.mail = data.getReader()["mail"].ToString();
                    persona.user.password = data.getReader()["password"].ToString();
                    persona.user.profile = data.getReader()["profile"].ToString();
                }
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool checkPersonExistence(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select count(*) from Personas " +
                    "inner join Usuarios on Personas.id = Usuarios.idPersona " +
                    "where Personas.dni = '" + persona.dni + "' and Usuarios.mail = '" + persona.user.mail + "';");
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
        public void newPersona(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "insert into Personas values (" +
                    "'" + persona.nombre + "', " +
                    "'" + persona.apellido + "', " +
                    "'" + persona.dni + "', " +
                    "'" + persona.fechaNacimiento.ToUniversalTime() + "');");
                data.sendStatement();

                personaService pServ = new personaService();
                persona.id = pServ.getLastPersonaID();
                persona.user.idPersona = persona.id;

                userService uServ = new userService();
                uServ.newUsuario(persona.user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public long getLastPersonaID()
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select top 1 Personas.id " +
                    "from Personas " +
                    "order by Personas.id DESC;");
                data.sendQuery();
                data.getReader().Read();
                return (long)data.getReader()["id"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool updatePersonaByIdAndDNI(personaModel _persona, int _oldDNI, long _oldID)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("" +
                    "update Personas " +
                    "set nombre = '" + _persona.nombre + "', apellido = '" + _persona.apellido + "', dni = '" + _persona.dni + "'" +
                    ", fechaNacimiento = '" + _persona.fechaNacimiento + "' " +
                    "where dni = '" + _oldDNI + "' and id = '" + _oldID + "';");
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