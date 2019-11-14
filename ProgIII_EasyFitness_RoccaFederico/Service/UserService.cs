using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;
using Utils;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class UserService
    {
        public bool validateUserLogin(UsuarioModel user)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Usuarios where Mail = '" + user.mail + "' and Password = '" + user.password + "'");
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

        public bool userPasswordRecover(UsuarioModel user)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Usuarios where Mail = '" + user.mail + "'");
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

        public string passwordRecover(UsuarioModel user)
        {
            try
            {
                UsuarioModel usr = new UsuarioModel();
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Usuarios where Mail = '" + user.mail + "'");
                data.sendQuery();
                while( data.getReader().Read() )
                {
                    usr.password = data.getReader()["password"].ToString();
                }

                return usr.password;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void sendUserPassword(UsuarioModel user)
        {
            try
            {
                MailSender mail = new MailSender("easyfitnessrecover@gmail.com", "453by6g3gy56gy534");
                mail.sendMail(
                    "EasyFitnessRecover@gmail.com",
                    user.mail.ToString(),
                    "Recuperación de cuenta EasyFitness",
                    "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-micro" +
                    "soft-com:office:office\"><head>  <title></title>  <!--[if !mso]><!-- -->  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"" +
                    ">  <!--<![endif]--><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><meta name=\"viewport\" content=\"width" +
                    "=device-width, initial-scale=1.0\"><style type=\"text/css\">  #outlook a { padding: 0; }  .ReadMsgBody { width: 100%; }  .Externa" +
                    "lClass { width: 100%; }  .ExternalClass * { line-height:100%; }  body { margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -m" +
                    "s-text-size-adjust: 100%; }  table, td { border-collapse:collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }  img { border:" +
                    " 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }  p { display: block" +
                    "; margin: 13px 0; }</style><!--[if !mso]><!--><style type=\"text/css\">  @media only screen and (max-width:480px) {    @-ms-viewp" +
                    "ort { width:320px; }    @viewport { width:320px; }  }</style><!--<![endif]--><!--[if mso]><xml>  <o:OfficeDocumentSettings>    <o" +
                    ":AllowPNG/>    <o:PixelsPerInch>96</o:PixelsPerInch>  </o:OfficeDocumentSettings></xml><![endif]--><!--[if lte mso 11]><style typ" +
                    "e=\"text/css\">  .outlook-group-fix {    width:100% !important;  }</style><![endif]--><!--[if !mso]><!-->    <link href=\"https:/" +
                    "/fonts.googleapis.com/css?family=Ubuntu:300,400,500,700\" rel=\"stylesheet\" type=\"text/css\">    <style type=\"text/css\">     " +
                    "   @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);    </style>  <!--<![endif]--><style type=\"text/c" +
                    "ss\">        .hide_on_mobile { display: none !important;}         @media only screen and (min-width: 480px) { .hide_on_mobile { d" +
                    "isplay: table-row !important;} }        [owa] .mj-column-per-100 {            width: 100%!important;          }          [owa] .m" +
                    "j-column-per-50 {            width: 50%!important;          }          [owa] .mj-column-per-33 {            width: 33.33333333333" +
                    "3336%!important;          }        </style><style type=\"text/css\">  @media only screen and (min-width:480px) {    .mj-column-pe" +
                    "r-100 { width:100%!important; }  }</style></head><body style=\"background: #000000;\">    <div class=\"mj-container\" style=\"bac" +
                    "kground-color:#000000;\"><!--[if mso | IE]>      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" wi" +
                    "dth=\"600\" align=\"center\" style=\"width:600px;\">        <tr>          <td style=\"line-height:0px;font-size:0px;mso-line-heig" +
                    "ht-rule:exactly;\">      <![endif]--><div style=\"margin:0px auto;max-width:600px;\"><table role=\"presentation\" cellpadding=\"0" +
                    "\" cellspacing=\"0\" style=\"font-size:0px;width:100%;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;v" +
                    "ertical-align:top;direction:ltr;font-size:0px;padding:9px 0px 9px 0px;\"><!--[if mso | IE]>      <table role=\"presentation\" bor" +
                    "der=\"0\" cellpadding=\"0\" cellspacing=\"0\">        <tr>          <td style=\"vertical-align:top;width:600px;\">      <![endif]" +
                    "--><div class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13p" +
                    "x;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"vertical-align:top;\" wi" +
                    "dth=\"100%\" border=\"0\"><tbody><tr><td style=\"word-wrap:break-word;font-size:0px;padding:0px 0px 0px 0px;\" align=\"center\"><" +
                    "table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse;border-spacing:0px;\" align=\"ce" +
                    "nter\" border=\"0\"><tbody><tr><td style=\"width:600px;\"><img alt height=\"auto\" src style=\"border:none;border-radius:0px;disp" +
                    "lay:block;font-size:13px;outline:none;text-decoration:none;width:100%;height:auto;\" width=\"600\"></td></tr></tbody></table></td" +
                    "></tr></tbody></table></div><!--[if mso | IE]>      </td></tr></table>      <![endif]--></td></tr></tbody></table></div><!--[if m" +
                    "so | IE]>      </td></tr></table>      <![endif]-->      <!--[if mso | IE]>      <table role=\"presentation\" border=\"0\" cellpa" +
                    "dding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\">        <tr>          <td style=\"line-height" +
                    ":0px;font-size:0px;mso-line-height-rule:exactly;\">      <![endif]--><div style=\"margin:0px auto;max-width:600px;\"><table role=" +
                    "\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;\" align=\"center\" border=\"0\"><tbody><tr" +
                    "><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px 20px 0px;\"><!--[if mso | IE]>    " +
                    "  <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">        <tr>          <td style=\"vertical-align:" +
                    "top;width:600px;\">      <![endif]--><div class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline" +
                    "-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\"" +
                    " width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-wrap:break-word;font-size:0px;padding:10px 25px;padding-top:10px;padding" +
                    "-bottom:10px;padding-right:10px;padding-left:10px;\"><p style=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:" +
                    "100%;\"></p><!--[if mso | IE]><table role=\"presentation\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" styl" +
                    "e=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:100%;\" width=\"600\"><tr><td style=\"height:0;line-height:0" +
                    ";\"> </td></tr></table><![endif]--></td></tr><tr><td style=\"word-wrap:break-word;font-size:0px;padding:15px 15px 15px 15px;\" al" +
                    "ign=\"left\"><div style=\"cursor:auto;color:#FFFFFF;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1" +
                    ".5;text-align:left;\"><p>Hola!<br>Recibimos una solicitud para recuperar tu cuenta.</p><p>Si no lo solicitaste elimin&#xE1; este " +
                    "mail para evitar que tu contrase&#xF1;a quede ac&#xE1;.</p><p>Tu contrase&#xF1;a es: " + passwordRecover(user) +
                    "&#xA0;</p><p>Gracias por elegir EasyFitness! " +
                    "Todo el entrenamiento en un solo lugar</p></div></td></tr><tr><td style=\"word-wrap:break-word;font-size:0px;padding:20px 20px 20" +
                    "px 20px;\" align=\"center\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:separate;wid" +
                    "th:100%;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"border:0px solid #000;border-radius:24px;color:#fff;cursor:auto;p" +
                    "adding:9px 26px;\" align=\"center\" valign=\"middle\" bgcolor=\"#1A1A1A\"><a href=\"https://google.com\" style=\"text-decoration:" +
                    "none;background:#1A1A1A;color:#fff;font-family:Ubuntu, Helvetica, Arial, sans-serif, Helvetica, Arial, sans-serif;font-size:13px;" +
                    "font-weight:normal;line-height:120%;text-transform:none;margin:0px;\" target=\"_blank\">ir a EasyFitness</a></td></tr></tbody></t" +
                    "able></td></tr><tr><td style=\"word-wrap:break-word;font-size:0px;padding:10px 25px;padding-top:10px;padding-bottom:10px;padding-" +
                    "right:10px;padding-left:10px;\"><p style=\"font-size:1px;margin:0px auto;border-top:1px solid #FFFFFF;width:100%;\"></p><!--[if m" +
                    "so | IE]><table role=\"presentation\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px;mar" +
                    "gin:0px auto;border-top:1px solid #FFFFFF;width:100%;\" width=\"600\"><tr><td style=\"height:0;line-height:0;\"> </td></tr></tabl" +
                    "e><![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>      </td></tr></table>      <![endif]--></td></tr></tbody></tab" +
                    "le></div><!--[if mso | IE]>      </td></tr></table>      <![endif]--></div></body></html>");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool mailExists(string _Mail)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select count(*) from Usuarios where Mail = '" + _Mail + "'");
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