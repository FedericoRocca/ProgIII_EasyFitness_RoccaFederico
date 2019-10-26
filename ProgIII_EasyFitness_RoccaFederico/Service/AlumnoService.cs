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
                aux.mail = data.getReader()["Mail"].ToString();
                aux.nombre = data.getReader()["Nombre"].ToString();
                aux.password = data.getReader()["Password"].ToString();
                aux.teams = (List<TeamModel>)data.getReader()["Teams"];

                return aux;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}