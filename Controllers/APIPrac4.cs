using Microsoft.AspNetCore.Mvc;
using Prac4.Factory_Roll;
using Prac4.Logica;
using Prac4.ModeloReporte;
using Prac4.Models_User;
using Prac4.Servicio;
using Microsoft.Extensions.DependencyInjection;
using Prac4.Archivo_Json;
using Microsoft.Extensions.Logging.EventLog;
using Prac4.Factory_Roll;
using Prac4.Correo.ModelsCorreo;
using Prac4.Correo.Services;
using Prac4.Correo;

namespace Prac4.Controllers
{
    [ApiController]
    [Route("/Prac4JuanR054r10")]
    public class APIPrac4 : ControllerBase
    {
        private readonly InicioSesion serviceInicio;
        private readonly IConfiguration configuration;
        private readonly Reporte resolucion;
        public APIPrac4(InicioSesion serviceInicio, IConfiguration configuration, Prac4.Servicio.Reporte reporte)
        {
            this.serviceInicio = serviceInicio;
            this.configuration = configuration;
            this.resolucion = reporte;
        }

        [HttpPost]
        [Route("/R3g15t7ro")]
        public IActionResult Registro([FromBody] UsuarioInformacion info)
        {
            if (info != null)
            {
                IRoll rollAndInsert = FactoryRoll.GetRoll(info);
                //rollAndInsert.Roll(info);
                EnviarCorreoDeRegistroExitoso(info.mailAddress, info.userName, info.password);
                return Ok("Registro exitoso");
            }
            else
            {
                return BadRequest("Datos de usuario no validos");
            }

        }

        private void EnviarCorreoDeRegistroExitoso(string email, string username, string Password)
        {
            try
            {
                var gmailService = new GmailService(configuration);
                var metodoGmail = new MetodoGmail(gmailService);

                string asunto = "Registro en Farmacia SURYS";
                string contenido = "Se ha registrado en Farmacia SURYS, se ha confirmado su correo automáticamente. " +
                    "Su Username: " + username + " " +
                    "  Su Contraseña: " + Password;

                GemailDTO correo = new GemailDTO
                {
                    Para = email,
                    Asunto = asunto,
                    Contenido = contenido
                };

                metodoGmail.SendGmail(correo.Para, correo.Asunto, correo.Contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo de registro: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("1niCI053510n")]
        public IActionResult InicioDeSesion([FromBody] InicioUsuario info)
        {
            string inicioExitoso = serviceInicio.IniciarSesion(info);

            if (inicioExitoso != null)
            {
                return Ok(inicioExitoso);
            }
            else
            {
                return BadRequest("Usuario no encontrado");
            }

        }

        [HttpPost]
        [Route("R3p0rT3")]
        public IActionResult CrearReporte([FromBody] CuerpoReporte reporte)
        {
            string RegistroExitoso = resolucion.reporte(reporte);

            if ( reporte != null)
            {
                return Ok(RegistroExitoso);
            }
            else
            {
                return BadRequest("Hubo en error");
            }
        }
    }
}



