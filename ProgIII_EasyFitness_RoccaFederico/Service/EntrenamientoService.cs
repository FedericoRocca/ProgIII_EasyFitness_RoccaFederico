﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class EntrenamientoService
    {
        public bool newEntrenamiento(EntrenamientoModel _entrenamiento)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "insert into Entrenamientos " +
                    "values ('" + _entrenamiento.idPersona + "', '" + _entrenamiento.descripcion + "', '" + _entrenamiento.nombre + "')");
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

        public bool updateEntrenamiento(EntrenamientoModel _entrenamiento)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "update Entrenamientos" +
                    " set descripcion = '" + _entrenamiento.descripcion + "', nombre = '" + _entrenamiento.nombre + "' " +
                    "where id = '" + _entrenamiento.id + "'");
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

        public bool deleteEntrenamiento(EntrenamientoModel _entrenamiento)
        {
            try
            {
                //Primero, obtengo la lista de rutinas a eliminar a partir del id de entrenamiento
                List<long> listaRutinas = new List<long>();
                RutinaService rServ = new RutinaService();
                listaRutinas = rServ.getRutinasByEntrenamientoId(_entrenamiento);

                //Ahora, obtengo la lista de ejercicios a eliminar a partir de los id de rutinas
                List<long> listaEjercicios = new List<long>();
                EjercicioService eServ = new EjercicioService();
                listaEjercicios = eServ.getIdEjerciciosByRutinaID(listaRutinas);

                if (listaEjercicios.Count > 0)
                {
                    eServ.deleteEjerciciosByIds(listaEjercicios);
                }

                if (listaRutinas.Count > 0)
                {
                    rServ.deleteRutinasByIds(listaRutinas);
                }

                DDBBGateway data = new DDBBGateway();
                data.prepareStatement(
                    "delete from Entrenamientos" +
                    " where Entrenamientos.id = '" + _entrenamiento.id + "'");
                data.sendStatement();


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntrenamientoModel> getEntrenamientosByPersonaID(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Entrenamientos where idPersona = '" + persona.id + "'");
                data.sendQuery();
                List<EntrenamientoModel> auxList = new List<EntrenamientoModel>();
                while (data.getReader().Read())
                {
                    EntrenamientoModel aux = new EntrenamientoModel();
                    aux.descripcion = data.getReader()["descripcion"].ToString();
                    aux.nombre = data.getReader()["nombre"].ToString();
                    aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    aux.id = long.Parse(data.getReader()["id"].ToString());
                    auxList.Add(aux);
                }
                return auxList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntrenamientoModel getEntrenamientoByPersonaID(personaModel persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Entrenamientos where idPersona = '" + persona.id + "'");
                data.sendQuery();
                data.getReader().Read();
                EntrenamientoModel aux = new EntrenamientoModel();
                aux.descripcion = data.getReader()["descripcion"].ToString();
                aux.nombre = data.getReader()["nombre"].ToString();
                aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                aux.id = long.Parse(data.getReader()["id"].ToString());
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EntrenamientoModel getEntrenamientoByID(long idEntrenamiento)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Entrenamientos where id = '" + idEntrenamiento + "'");
                data.sendQuery();
                data.getReader().Read();
                EntrenamientoModel aux = new EntrenamientoModel();
                aux.descripcion = data.getReader()["descripcion"].ToString();
                aux.nombre = data.getReader()["nombre"].ToString();
                aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                aux.id = long.Parse(data.getReader()["id"].ToString());
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}