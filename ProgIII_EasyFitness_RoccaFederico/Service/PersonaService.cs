using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataGateway;
using ProgIII_EasyFitness_RoccaFederico.Models;
using Utils;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class PersonaService
    {

        public PersonaModel getPersonaByMail(string _Mail)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "select Personas.id, Personas.nombre, Personas.apellido, Personas.dni, Personas.fechaNacimiento, Usuarios.mail " +
                    "from Personas " +
                    "inner join Usuarios on Personas.userID = Usuarios.id " +
                    "where mail = '" + _Mail + "'");
                data.sendQuery();
                PersonaModel tmp = new PersonaModel();
                data.getReader().Read();
                tmp.id = int.Parse(data.getReader()["id"].ToString());
                tmp.nombre = data.getReader()["nombre"].ToString();
                tmp.apellido = data.getReader()["apellido"].ToString();
                tmp.dni = (int)data.getReader()["dni"];
                tmp.fechaNacimiento = DateTime.Parse(data.getReader()["fechaNacimiento"].ToString());
                tmp.user.mail = data.getReader()["mail"].ToString();
                tmp.edad = (short)Math.Floor((DateTime.Now - tmp.fechaNacimiento.Date).TotalDays / 365.25D);
                return tmp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool DNIExists(int _DNI)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Personas where dni = '" + _DNI + "';");
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

        public void altaPersona( PersonaModel _Persona )
        {
            try
            {
                DDBBGateway userData = new DDBBGateway();
                DDBBGateway personaData = new DDBBGateway();
                userData.prepareQuery("insert into Usuarios values('" + _Persona.user.mail + "', '" + _Persona.user.password + "');");
                userData.sendStatement();
                if(userData.getAffectedRows() <= 0)
                {
                    throw new Exception("Error al dar de alta usuario en base de datos");
                }
                DDBBGateway userQueryID = new DDBBGateway();
                userQueryID.prepareQuery("select top 1 id as id from Usuarios order by id DESC");
                userQueryID.sendQuery();
                userQueryID.getReader().Read();
                int userId = int.Parse(userQueryID.getReader()["id"].ToString());
                personaData.prepareQuery("insert into Personas values ('" +  _Persona.nombre + "', " +
                    "'" + _Persona.apellido + "', '" + _Persona.dni + "', '" + _Persona.fechaNacimiento.Date + "', '" + userId + "')");
                personaData.sendQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void sendUserDataMail(PersonaModel persona)
        {
            try
            {
                MailSender mail = new MailSender("easyfitnessrecover@gmail.com", "453by6g3gy56gy534");
                mail.sendMail(
                    "EasyFitnessRecover@gmail.com",
                    persona.user.mail.ToString(),
                    "Registro de cuenta EasyFitness",
                    "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:of" +
                    "fice:office\"><head>  <title></title>  <!--[if !mso]><!-- -->  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">  <!--<![endif]--><m" +
                    "eta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0" +
                    "\"><style type=\"text/css\">  #outlook a { padding: 0; }  .ReadMsgBody { width: 100%; }  .ExternalClass { width: 100%; }  .ExternalClass * {" +
                    " line-height:100%; }  body { margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }  table, td { border-collap" +
                    "se:collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }  img { border: 0; height: auto; line-height: 100%; outline: none; text-decorati" +
                    "on: none; -ms-interpolation-mode: bicubic; }  p { display: block; margin: 13px 0; }</style><!--[if !mso]><!--><style type=\"text/css\">  @me" +
                    "dia only screen and (max-width:480px) {    @-ms-viewport { width:320px; }    @viewport { width:320px; }  }</style><!--<![endif]--><!--[if ms" +
                    "o]><xml>  <o:OfficeDocumentSettings>    <o:AllowPNG/>    <o:PixelsPerInch>96</o:PixelsPerInch>  </o:OfficeDocumentSettings></xml><![endif]--" +
                    "><!--[if lte mso 11]><style type=\"text/css\">  .outlook-group-fix {    width:100% !important;  }</style><![endif]--><!--[if !mso]><!-->    " +
                    "<link href=\"https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700\" rel=\"stylesheet\" type=\"text/css\">    <style type=\"text/cs" +
                    "s\">        @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);    </style>  <!--<![endif]--><style type=\"text/css" +
                    "\">        .hide_on_mobile { display: none !important;}         @media only screen and (min-width: 480px) { .hide_on_mobile { display: table" +
                    "-row !important;} }        [owa] .mj-column-per-100 {            width: 100%!important;          }          [owa] .mj-column-per-50 {       " +
                    "     width: 50%!important;          }          [owa] .mj-column-per-33 {            width: 33.333333333333336%!important;          }        " +
                    "</style><style type=\"text/css\">  @media only screen and (min-width:480px) {    .mj-column-per-100 { width:100%!important; }  }</style></he" +
                    "ad><body style=\"background: #000000;\">    <div class=\"mj-container\" style=\"background-color:#000000;\"><!--[if mso | IE]>      <table r" +
                    "ole=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\">        <tr>    " +
                    "      <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">      <![endif]--><div style=\"margin:0px auto;max-width:600" +
                    "px;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;\" align=\"center\" border=\"0\"><tb" +
                    "ody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:9px 0px 9px 0px;\"><!--[if mso | IE]>      <tab" +
                    "le role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">        <tr>          <td style=\"vertical-align:top;width:600px;\\" +
                    "\" >      < ![endif]-- >< div class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-si" +
                    "ze:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"vertical-align:top;\" width=\\" +
                    "\"100%\" border=\"0\"><tbody></tbody></table></div><!--[if mso | IE]>      </td></tr></table>      <![endif]--></td></tr></tbody></table></di" +
                    "v><!--[if mso | IE]>      </td></tr></table>      <![endif]-->      <!--[if mso | IE]>      <table role=\"presentation\" border=\"0\" cellpa" +
                    "dding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\">        <tr>          <td style=\"line-height:0px;font-s" +
                    "ize:0px;mso-line-height-rule:exactly;\">      <![endif]--><div style=\"margin:0px auto;max-width:600px;\"><table role=\"presentation\" cellp" +
                    "adding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;ve" +
                    "rtical-align:top;direction:ltr;font-size:0px;padding:20px 0px 20px 0px;\"><!--[if mso | IE]>      <table role=\"presentation\" border=\"0\" " +
                    "cellpadding=\"0\" cellspacing=\"0\">        <tr>          <td style=\"vertical-align:top;width:600px;\">      <![endif]--><div class=\"mj-co" +
                    "lumn-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\">" +
                    "<table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"vertical-align:top;\" width=\"100%\" border=\"0\"><tbody><tr><td st" +
                    "yle=\"word-wrap:break-word;font-size:0px;padding:10px 25px;padding-top:10px;padding-bottom:10px;padding-right:10px;padding-left:10px;\"><p s" +
                    "tyle=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:100%;\"></p><!--[if mso | IE]><table role=\"presentation\" align=\"c" +
                    "enter\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:100%;\" wi" +
                    "dth=\"600\"><tr><td style=\"height:0;line-height:0;\"> </td></tr></table><![endif]--></td></tr><tr><td style=\"word-wrap:break-word;font-siz" +
                    "e:0px;padding:15px 15px 15px 15px;\" align=\"left\"><div style=\"cursor:auto;color:#FFFFFF;font-family:Ubuntu, Helvetica, Arial, sans-serif;" +
                    "font-size:11px;line-height:1.5;text-align:left;\"><p>Hola!<br>Te confirmamos tu solicitud de registro en EasyFitness.</p><p>Los datos regist" +
                    "rados son:</p><p>Mail: " + persona.user.mail + "&#xA0;</p><p>Nombre: " + persona.nombre + "&#xA0;</p><p>Apellido: " + persona.apellido + "</p><p>DNI: " + persona.dni + "&#xA0;</p><p>Fecha de nacimiento: " + persona.fechaNacimiento.ToString("dd/MM/yyyy") + "</p><p>Gracias por elegir EasyFi" +
                    "tness! Todo el entrenamiento en un solo lugar</p></div></td></tr><tr><td style=\"word-wrap:break-word;font-size:0px;padding:20px 20px 20px 2" +
                    "0px;\" align=\"center\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:separate;width:100%;\" alig" +
                    "n=\"center\" border=\"0\"><tbody><tr><td style=\"border:0px solid #000;border-radius:24px;color:#fff;cursor:auto;padding:9px 26px;\" align=\\" +
                    "\"center\" valign=\"middle\" bgcolor=\"#1A1A1A\"><a href=\"https://google.com\" style=\"text-decoration:none;background:#1A1A1A;color:#fff;fo" +
                    "nt-family:Ubuntu, Helvetica, Arial, sans-serif, Helvetica, Arial, sans-serif;font-size:13px;font-weight:normal;line-height:120%;text-transfo" +
                    "rm:none;margin:0px;\" target=\"_blank\">ir a EasyFitness</a></td></tr></tbody></table></td></tr><tr><td style=\"word-wrap:break-word;font-si" +
                    "ze:0px;padding:10px 25px;padding-top:10px;padding-bottom:10px;padding-right:10px;padding-left:10px;\"><p style=\"font-size:1px;margin:0px au" +
                    "to;border-top:1px solid #FFFFFF;width:100%;\"></p><!--[if mso | IE]><table role=\"presentation\" align=\"center\" border=\"0\" cellpadding=\\" +
                    "\"0\" cellspacing=\"0\" style=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:100%;\" width=\"600\"><tr><td style=\"height" +
                    ":0;line-height:0;\"> </td></tr></table><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>      </td></tr></table>      <![endif]" +
                    "--></td></tr></tbody></table></div><!--[if mso | IE]>      </td></tr></table>      <![endif]--></div></body></html>");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}