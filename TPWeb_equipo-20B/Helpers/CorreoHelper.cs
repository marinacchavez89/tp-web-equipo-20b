using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace TPWeb_equipo_20B.Helpers
{
    public class CorreoHelper
    {
        public static void EnviarCorreoConfirmacion(string emailCliente, string nombreCliente, string codigoVoucher)
        {
            try
            {
                // Definir el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("progratresmarjuanmartin@gmail.com");
                mensaje.To.Add(new MailAddress(emailCliente));  
                mensaje.Subject = "Registro Exitoso - ¡Gracias por Participar!";
                mensaje.Body = $"<h1>¡Hola, {nombreCliente}!</h1>" +
                               $"<p>Gracias por registrarte y participar en nuestra promoción. Tu código de voucher <b>{codigoVoucher}</b> se ha registrado exitosamente.</p>" +
                               $"<p>Buena suerte y esperamos que ganes uno de nuestros premios. ¡Gracias por tu preferencia!</p>" +
                               $"<br/>" +
                               $"<p>Atentamente,</p>" +
                               $"<p>El Equipo de la Promoción</p>";
                mensaje.IsBodyHtml = true;

                // Configurar el cliente SMTP para Gmail
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);  //el servidor smtp OJO, SOLO FUNCIONA CON ESE PUERTO Y NO FUNCIONA CON NINGUNO MAS
                smtpClient.Credentials = new NetworkCredential("progratresmarjuanmartin@gmail.com", "ndgo fttt cyio rrrs"); // esta es la api key que tenemos que usar
                smtpClient.EnableSsl = true; 

                // Enviar el mensaje
                smtpClient.Send(mensaje);
            }
            catch (Exception ex)
            {
              
                throw new Exception("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
