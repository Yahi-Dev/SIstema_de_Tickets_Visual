using Prac4.Estrategy;
using Prac4.Estrategy.Entidades;
using Prac4.Logica;
using Prac4.ModeloReporte;
using Prac4.Models_User;

namespace Prac4.Servicio
{
    public class Reporte
    {
        private readonly IConfiguration configuration;
        private readonly FactoryMensajeria factory;
        private readonly MContexto contexto;
        public Reporte(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string reporte (CuerpoReporte reporte)
        {
            if (reporte == null)
            {
                return "Hubo un error con el reporte";
            }

           ResolucionEstrategy resolucion = new ResolucionEstrategy(configuration, factory, contexto);
           return resolucion.PutReporte (reporte);


        }
    }
}
