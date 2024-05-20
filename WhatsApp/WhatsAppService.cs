using Prac4.Estrategy;
using Prac4.Estrategy.Entidades;

namespace Prac4.WhatsApp
{
    public class WhatsAppService
    {
        private readonly IMensajeria WSmensajeria;

        public WhatsAppService(IMensajeria Dato)
        {
            WSmensajeria = Dato;
        }

        public void EnviarMensaje(CuerpoMensaje datos)
        {
           WSmensajeria.SendAll(datos);
        }
    }
}
