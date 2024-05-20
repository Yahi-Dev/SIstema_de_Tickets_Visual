using Prac4.Estrategy.Entidades;
using Prac4.Servicio;
using Prac4.ModeloReporte;
using Prac4.Correo.Services;
using Prac4.Correo;
using Prac4.Correo.ModelsCorreo;
using Prac4.Estrategy;

    namespace Prac4.ResolucionEnvio
    {
        public class MensajeriaEnvia
        {
            private readonly FactoryMensajeria Factory;
            private readonly IConfiguration configuration;
            private readonly MContexto mContexto;

            IGmailService gmailService;
            public MensajeriaEnvia(IConfiguration configuration, FactoryMensajeria fac, MContexto mContexto)
            {
                this.configuration = configuration;
                Factory = fac;
                this.mContexto = mContexto;
            }

            public void Mensajeria(CuerpoReporte reporte)
            {
                //if (Factory == null)
                //{
                //    throw new Exception("El objeto Factory no ha sido inicializado correctamente.");
                //}

                var gmailService = new GmailService(configuration);
                var metodoGmail = new MetodoGmail(gmailService);

                string nombre = reporte.Nombre;
                string apellido = reporte.Apellido;
                string puesto = reporte.Puesto;
                string contenido = reporte.Contenido;
                string numero = reporte.Numero;
                string correo = reporte.Correo;
                string appMensajeria = reporte.Clave;
                string idTelegram = reporte.IdTelegram;

                string asunto = nombre + " " + apellido + " Se ha generado un Tickect para un reporte";
                string informacion = nombre + " del puesto " + puesto + " Su Reporte ha redactar, fue: " + contenido;

                GemailDTO email = new GemailDTO
                {
                    Para = correo,
                    Asunto = asunto,
                    Contenido = informacion
                };

                CuerpoMensaje WhatsApp = new CuerpoMensaje
                {
                    Numero = numero,
                    Mensaje = informacion
                };

                CuerpoMensaje Telegram = new CuerpoMensaje
                {
                    Numero = idTelegram,
                    Mensaje = informacion
                };

                string app = reporte.Clave;
            MContexto contexto = null;
                contexto = new MContexto(objeto: Factory.GetMensajeria(app, configuration, gmailService));

            switch (appMensajeria)
                {
                    case "1":
                        contexto.Ejecutar(WhatsApp);
                        break;

                    case "2":
                        contexto.Ejecutar(Telegram);
                        break;

                    case "3":
                        metodoGmail.SendGmail(email.Para, email.Asunto, email.Contenido);
                        break;
                }
            }
        }
    }

