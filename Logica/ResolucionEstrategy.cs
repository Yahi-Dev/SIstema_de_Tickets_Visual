using Prac4.ModeloReporte;
using Prac4.Archivo_Txt_Historial_Registro;
using Prac4.Correo.ModelsCorreo;
using Prac4.ResolucionEnvio;
using Prac4.Estrategy;

namespace Prac4.Logica
{
    public class ResolucionEstrategy
    {
        private readonly IConfiguration configuration;
        private readonly FactoryMensajeria factory;
        private readonly MContexto contexto;
        public ResolucionEstrategy(IConfiguration configuration, FactoryMensajeria factory, MContexto mcontexto)
        {
            this.configuration = configuration;
            this.factory = factory;
            this.contexto = mcontexto;
        }
        public string PutReporte(CuerpoReporte reporte)
        {
            string nombre = reporte.Nombre;
            string apellido = reporte.Apellido;
            string puesto = reporte.Puesto;
            string contenido = reporte.Contenido;
            string numero = reporte.Numero;
            string correo = reporte.Correo;
            string appMensajeria = reporte.Clave;

            Logger.Instance.LogReporte(nombre,apellido,puesto,contenido,numero,correo);

            MensajeriaEnvia enviar = new MensajeriaEnvia(configuration, factory, contexto);
            enviar.Mensajeria(reporte);

            


           return("Funciona");
        }
    }
}
